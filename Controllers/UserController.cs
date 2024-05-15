using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiForPsycho.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiForPsycho.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [Route("GetUsers")]
        [HttpGet]
        public List<UsersTestResults> GetUsers()
        {
            using (PsychoTestsContext DB = new PsychoTestsContext())
            {
                List<UsersTestResults> utr = new List<UsersTestResults>();
                List<User> users = DB.Users.Where(x=>x.IdRole==2).ToList();
                foreach (var user in users)
                {
                    UsersTest ut = DB.UsersTests.Where(x => x.IdUser == user.UserId).Include("IdResultNavigation").FirstOrDefault();
                    Result? rt = DB.Results.Where(x => x.ResultId == ut.IdResult).Include("IdTestNavigation").FirstOrDefault();
                    utr.Add(new UsersTestResults
                    {
                        Id = user.UserId,
                        Fullname = user.Surname + " " + user.Name + " " + user.Patronymic,
                        NameOfResult = ut.IdResultNavigation.ResultName,
                        NameOfTest = rt.IdTestNavigation.TestName
                    });
                }
                return utr;

            }
        }
    }
}
