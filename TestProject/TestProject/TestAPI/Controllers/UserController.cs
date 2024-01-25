using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAPI.DAL;
using TestAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDBContext _context;

        public UserController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUserList()
        {
            try
            {
                var _vUsers = _context.Users.ToList();
                if (_vUsers.Count == 0)
                {
                    return NotFound("User Details List Not Found");
                }
                return Ok(_vUsers);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        //[HttpGet("{id}")]
        //public IActionResult GetUserDetailsById(int id)
        //{
        //    try
        //    {
        //        var _vUsers = _context.Users.Find(id);
        //        if (_vUsers == null)
        //        {
        //            return NotFound($"User Details List Not Found with Id {id}");
        //        }
        //        return Ok(_vUsers);
        //    }
        //    catch (Exception ex)
        //    {

        //        return BadRequest(ex.Message);
        //    }
        //}

        [HttpPost]
        public IActionResult Post(User objModel)
        {
            try
            {
                _context.Add(objModel);
                _context.SaveChanges();
                return Ok("User Created Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public IActionResult Put(User objModel)
        {
            try
            {
                if (objModel == null || objModel.Id == 0)
                {
                    if (objModel == null)
                    {
                        return BadRequest("Model data is Invalid");
                    }
                    if (objModel.Id == 0)
                    {
                        return NotFound($"User Id {objModel.Id } is Invalid");
                    }
                }
                var _vUser = _context.Users.Find(objModel.Id);
                if (_vUser == null)
                {
                    return NotFound($"User Details with Id {objModel.Id } not found.");
                }
                _vUser.UserName = objModel.UserName;
                _vUser.Email = objModel.Email;
                _vUser.Mobile = objModel.Mobile;
                _vUser.Skills = objModel.Skills;
                _vUser.Hobby = objModel.Hobby;
                _context.SaveChanges();
                return Ok("User Updated Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            try
            {
                var _vUser = _context.Users.Find(Id);
                if (_vUser == null)
                {
                    return NotFound($"User Details with Id {Id } not found.");
                }
                _context.Users.Remove(_vUser);
                _context.SaveChanges();
                return Ok("User Details Deleted Successfully");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


    }
}
