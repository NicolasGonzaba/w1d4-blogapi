using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using w1d4_blogapi.Models;
using w1d4_blogapi.Models.DTO;
using w1d4_blogapi.Services.Context;

namespace w1d4_blogapi.Services;

public class UserService : ControllerBase
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

    public IEnumerable<UserModel> GetAllUsers()
    {
        return _context.UserInfo;
    }

    public IActionResult Login(LoginDTO user)
    {
        IActionResult result= Unauthorized();
        // If the user exists
        if (DoesUserExist(user.Username))
        {
            
            // Create a secret key to sign the JTW Token
            // This should be stored securley (not hard coded in production)
            var secretKey= new SymmetricSecurityKey(Encoding.UTF8.GetBytes("supersupersuperdupersecurekey@34444456789"));
            // Create signing credentials using the secret key and HMACSHA256 algorithm
            var signingCredentials=new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256); // Ensures the token can't be tampered with

            // Build the JWT with metadata

            var tokeOptions=new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signingCredentials
            );

            // Convert the token object into tsring that can be sent to client
            var tokenString= new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            // return the token as a JSON to the client
            result=Ok(new{Token=tokenString});
        }
        // Return either the token (If user exists) or unauthorized (If not)
        return result;
    }

    internal UserIdDTO GetUserIdDTOByUsername(string username)
    {
        throw new NotImplementedException();
    }
}
