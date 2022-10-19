﻿using Application.Core.Exceptions;
using CleanArch.Infra.Data.Context;
using Domain.Interfaces.User;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repository.Users
{
    public class UserRepository : IUserRepository
    {
        private U27ApplicationDBContext _ctx;

        public UserRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<User> Get()
        {
            return _ctx.Users;
        }

      
        public User Post(User user)
        {

            try
            {
                _ctx.Users.Add(user);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotFoundException("User", "El usuario no fue insertado");
            }

            return user;
        }


        public User Put(User user)
        {

            try
            {
                _ctx.Entry(user).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotFoundException("User", "El usuario no fue modificado");
            }

            return user;
        }


        public User PutStatusActivateUserById(User user)
        {

            try
            {
                user.Status = true;
                user.UpdatedAt = DateTime.Now;
                _ctx.Entry(user).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new NotFoundException("User", "El usuario no fue modificado" + ex.Message);
            }

            return user;
        }

        public User PutStatusDeactivateUserById(User user)
        {

            try
            {
                user.Status = false;
                user.UpdatedAt = DateTime.Now;
                _ctx.Entry(user).State = EntityState.Modified;
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new NotFoundException("User", "El usuario no fue modificado" + ex.Message);
            }

            return user;
        }

        public List<User> PostRange(List<User> user)
        {

            _ctx.Users.AddRange(user);

            try
            {
                _ctx.SaveChanges();
                return user;
            }
            catch (Exception)
            {

                throw new BadRequestException("El usuario no fue insertado");
            }
        }


        public bool Delete(User user)
        {

            try
            {
                _ctx.Remove(user);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {
                throw new NotFoundException("User", "El usuario no fue eliminado");
            }

            return true;
        }

        public bool DeleteUserRolRange(UserRol userRol)
        {

            try
            {
                _ctx.Remove(userRol);
                _ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw new NotFoundException("User Rol", "El rol del usuario no fue eliminado");
            }

            return true;
        }

        public bool PostSubCampaingUser(User user, int campaing)
        {

            try
            {
                _ctx.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new NotFoundException("User", "El usuario no fué modificado");
            }

            return true;
        }

    }
}
