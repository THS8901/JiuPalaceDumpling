using DumplingStore.DataAccess.Data;
using DumplingStore.Models;
using DumplingStore.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DumplingStore.DataAccess.DbInitializer
{
	public class DbInitializer : IDbInitializer
	{
		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly ApplicationDbContext _db;

		public DbInitializer(
			UserManager<IdentityUser> userManager,
			RoleManager<IdentityRole> roleManager,
			ApplicationDbContext db)
		{
			_roleManager = roleManager;
			_userManager = userManager;
			_db = db;
		}
		public void Initialize()
		{
			try
			{
				if (_db.Database.GetPendingMigrations().Count() > 0)
				{
					_db.Database.Migrate();
				}

			}
			catch (Exception ex)
			{

			}

			if (!_roleManager.RoleExistsAsync(SD.Role_Customer).GetAwaiter().GetResult())
			{
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Customer)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Manager)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Employee)).GetAwaiter().GetResult();
				_roleManager.CreateAsync(new IdentityRole(SD.Role_Admin)).GetAwaiter().GetResult();

				_userManager.CreateAsync(new ApplicationUser
				{
					UserName = "testadmin1@gmail.com",
					Email = "testadmin1@gmail.com",
					Name = "Administrator",
					PhoneNumber = "0987654321",
					Address = "台北市大安區中正路一段1234號",
					EmailConfirmed = true
				}, "Aa123456+").GetAwaiter().GetResult();

				ApplicationUser user = _db.ApplicationUsers.FirstOrDefault(u => u.Email == "testadmin1@gmail.com");
				_userManager.AddToRoleAsync(user, SD.Role_Admin).GetAwaiter().GetResult();

			}
			return;
		}
	}
}