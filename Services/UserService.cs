using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks;
using w1d4_blogapi.Models;
using w1d4_blogapi.Models.DTO;
using w1d4_blogapi.Services.Context;

namespace w1d4_blogapi.Services;

public class UserService
{

    private readonly DataContext _context;
    public UserService(DataContext context)
    {
        _context = context;
    }


    // We need a helper method to check if a user exists in our datbase
    public bool DoesUserExist(string username)
    {
        // Check our tables to see if the user name exists
        return _context.UserInfo.SingleOrDefault(user => user.Username == username) != null;
    }

    public bool AddUser(CreateAccountDTO userToAdd)
    {
        bool result=false;
        if (userToAdd.Username!= null&& !DoesUserExist(userToAdd.Username))
        {
            UserModel newUser=new();

            var HashedPassword=HashPassword(userToAdd.Password);

            newUser.Id=userToAdd.Id;
            newUser.Username=userToAdd.Username;

            newUser.Salt=HashedPassword.Salt;
            newUser.Hash=HashedPassword.Hash;
            
            _context.Add(newUser);

            return _context.SaveChanges() !=0;

     
        }
        return result;

        // we are going to need Hash heper function help us hash our password
        // We need to set our newUser.Id=UseerToAdd.Id
        // Username
        // Salt
        // Hash

        // then we add it to our DataContext
        // Save our Changes
        // return a bool to return true or false
    }
    
    // Function that will help us Hash our password
    public PasswordDTO HashPassword(string? password)
    {
        PasswordDTO newHashedPassword= new();

        byte[] SaltBytes=new byte[64];

        var provider = RandomNumberGenerator.Create();
        provider.GetNonZeroBytes(SaltBytes);

        var Salt=Convert.ToBase64String(SaltBytes);

        var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password ?? "", SaltBytes, 10000, HashAlgorithmName.SHA256);

        var Hash= Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

        newHashedPassword.Salt=Salt;
        newHashedPassword.Hash=Hash;

        return newHashedPassword;
    }

    // Helper function to verifyPassword
    public bool verifyUserPassword(string? Password, string? StoredHash, string? StoredSalt)
    {
        if (StoredSalt == null)
        {
            return false;
        } 

        var SaltBytes= Convert.FromBase64String(StoredSalt);

        var rfc2898DeriveBytes= new Rfc2898DeriveBytes(Password ?? "",SaltBytes, 10000, HashAlgorithmName.SHA256);
        
        var newHash=Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

        return newHash==StoredHash;
    }
}
