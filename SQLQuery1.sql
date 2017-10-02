  SELECT AspNetRoles.Name FROM AspNetUsers 
                LEFT JOIN AspNetUserRoles ON  AspNetUserRoles.UserId = AspNetUsers.Id 
                LEFT JOIN AspNetRoles ON AspNetRoles.Id = AspNetUserRoles.RoleId
                WHERE AspNetUsers.Email = 'test@test.com'
