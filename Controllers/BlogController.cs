using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using w1d4_blogapi.Models;
using w1d4_blogapi.Services;

namespace w1d4_blogapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogController : ControllerBase
{
    private readonly BlogItemService _data;

    public BlogController(BlogItemService dataFromService)
    {
        _data = dataFromService;
    }

    // AddBlogItems

    [HttpPost("AddBlogItems")]
    public bool AllBlogItems(BlogItemModel newBlogItem)
    {
        return _data.AddBlogItems(newBlogItem);
    }

    // get Blog items
    [HttpPost("")]

    public IEnumerable<BlogItemModel> GetAllBlogItems()
    {
        return _data.GetAllBlogItems();
    }

    // GetBlogItemsByCategory
    [HttpGet("GetBlogItemsByCategory/{categoty}")]

    public IEnumerable<BlogItemModel> GetItemsByCategory(string category)
    {
        return _data.GetBlogItemsByCategory(category);
    }

    // GetItemsByTag
    [HttpGet("GetItemsByTag/{tag}")]

    public List<BlogItemModel> GetItemsByTag(string tag)
    {
        return _data.GetItemsByTag(tag);
    }

    // GetItemsByDate
    [HttpGet("GetItemsByDate/{Date}")]

    public IEnumerable<BlogItemModel> GetItemsByDate(string date)
    {
        return _data.GetItemsByDate(date);
    }
    
    // UpdatedBlogItems
    [HttpPost("UpdatedBlogItems")]
    public bool UpdateBlogItems(BlogItemModel blogUpdate)
    {
        return _data.UpdateBlogItems(blogUpdate);
    }

    // DeleteBlogItems

    [HttpPut("DeleteBlogItems/{BlogItemToDelete}")]

    public bool DeleteBlogItem(BlogItemModel BlogItemToDelete)
    {
        return _data.DeleteBlogItem(BlogItemToDelete);
    }

    // GetPublishedBlogItems
    [HttpGet("GetPublishedItems")]

    public IEnumerable<BlogItemModel> GetPublishedItems(){
        return _data.GetPublishedItems();
    }

}
