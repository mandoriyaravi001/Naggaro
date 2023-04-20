using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookReading.DataAccessLayer;
using BookReading.Models;
using BookReading.Shared.ViewModels;
using Microsoft.AspNetCore.Identity;



namespace BookReading.BLL
{
    public class EventBLL : IEventBLL
    {
        //object for data access layer
        private readonly IEventDAL _eventDAL = null;
        public EventBLL(IEventDAL eventDAL)
        {
            _eventDAL = eventDAL;
        }



        //method for create event
        public async Task<bool> CreateEvent(EventViewModel eventViewModel)
        {
            await _eventDAL.CreateEvent(eventViewModel);
            return true;
        }



        //method for get all events
        public async Task<List<EventViewModel>> GetALLEvents()
        {
            var events = await _eventDAL.GetALLEvents();
            return events;
        }



        //method for get events according to id
        public async Task<EventViewModel> GetEvent(int id)
        {
            var events = await _eventDAL.GetEvent(id);
            return events;
        }



        //method for update event details
        public async Task<bool> UpdateEvent(int id, EventViewModel eventViewModel)
        {
            if (await _eventDAL.UpdateEvent(id, eventViewModel))
            {
                return true;
            }
            return false;
        }



        //method for update comments in comments box
        public async Task<bool> UpdateComment(CommentsViewModel commentsViewModel)
        {
            return await _eventDAL.UpdateComment(commentsViewModel);
        }



        //method for getting all comments on particular event
        public async Task<List<CommentsViewModel>> GetComments(int id, CommentsViewModel commentsViewModel)
        {
            return await _eventDAL.GetComments(id, commentsViewModel);
        }



        //method for create user (signup)
        public async Task<IdentityResult> CreateUser(SignUpUserModel signupUserModel)
        {
            return await _eventDAL.CreateUser(signupUserModel);
        }



        //method for login validation
        public async Task<SignInResult> PasswordSignInAsync(SignInModel signInModel)
        {
            return await _eventDAL.PasswordSignInAsync(signInModel);
        }



        //method for logout user
        public async Task SignOutAsync()
        {
            await _eventDAL.SignOutAsync();
        }
    }
}