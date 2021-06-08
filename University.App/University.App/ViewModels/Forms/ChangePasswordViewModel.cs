using System;
using System.Collections.Generic;
using System.Text;
using University.App.Helpers;
using University.App.Views.Forms;
using University.BL.DTOs;
using University.BL.Services.Implements;
using Xamarin.Forms;

namespace University.App.ViewModels.Forms
{
    public class ChangePasswordViewModel : BaseViewModel
    {
        #region Attributes
        private UserDTO _user;
        private string _oldPassword;
        private string _newPassword;
        private string _confirmPassword;
        private bool _isEnabled;
        private bool _isRunning;
        private ApiService _apiService;
        #endregion

        #region Properties
        public UserDTO User
        {
            get { return this._user; }
            set { this.SetValue(ref this._user, value); }
        }

        public string OldPassword
        {
            get { return this._oldPassword; }
            set { this.SetValue(ref this._oldPassword, value); }
        }

        public string NewPassword
        {
            get { return this._newPassword; }
            set { this.SetValue(ref this._newPassword, value); }
        }

        public string ConfirmPassword
        {
            get { return this._confirmPassword; }
            set { this.SetValue(ref this._confirmPassword, value); }
        }

        public bool IsEnabled
        {
            get { return this._isEnabled; }
            set { this.SetValue(ref this._isEnabled, value); }
        }

        public bool IsRunning
        {
            get { return this._isRunning; }
            set { this.SetValue(ref this._isRunning, value); }
        }
        #endregion

        #region Command
        public Command ChangePasswordCommand { get; set; }
        public Command GetUserCommand { get; set; }
        #endregion

        #region Methods
        async void GetUser()
        {
            try
            {
                var userID = Helpers.Settings.UserID;
                var responseDTO = await _apiService.RequestAPI<UserDTO>(Helpers.Endpoints.URL_BASE_UNIVERSITY_AUTH,
                    Helpers.Endpoints.GET_USER + "?userID=" + userID,
                    null,
                    ApiService.Method.Get,
                    true);

                if (responseDTO.Code == 200)
                {
                    this.User = (UserDTO)responseDTO.Data;
                    await Application.Current.MainPage.DisplayAlert("Notification", responseDTO.Message, "Accept");
                }
                else
                    await Application.Current.MainPage.DisplayAlert("Notification", responseDTO.Message, "Accept");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Notification", ex.Message, "Accept");
            }
        }

        async void ChangePasswordUser()
        {
            try
            {
                this.IsRunning = true;
                this.IsEnabled = false;

                if (!await _apiService.CheckConnection())
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;

                    await Application.Current.MainPage.DisplayAlert(Languages.Notification, Languages.NoInternetConnection, Languages.Accept);
                    return;
                }

                if (string.IsNullOrEmpty(OldPassword) || string.IsNullOrEmpty(NewPassword) || string.IsNullOrEmpty(ConfirmPassword))
                {
                    this.IsRunning = false;
                    this.IsEnabled = true;

                    await Application.Current.MainPage.DisplayAlert(Languages.Notification, Languages.FieldsRequired, Languages.Accept);
                    return;
                }

                var userID = Helpers.Settings.UserID;
                var changePasswordDTO = new ChangePasswordDTO()
                {
                    UserId = userID,
                    OldPassword = this.OldPassword,
                    NewPassword = this.NewPassword,
                    ConfirmPassword = this.ConfirmPassword
                };

                var responseDTO = await _apiService.RequestAPI<string>(Helpers.Endpoints.URL_BASE_UNIVERSITY_AUTH,
                   Helpers.Endpoints.CHANGE_PASSWORD,
                   changePasswordDTO,
                   ApiService.Method.Post,
                   true);

                if (responseDTO.Code == 200)
                {
                    await Application.Current.MainPage.DisplayAlert(Languages.Notification, "The password was changed successfully", Languages.Accept);
                    Application.Current.MainPage = new LoginPage();
                    this.IsRunning = false;
                    this.IsEnabled = true;
                }
                else
                    await Application.Current.MainPage.DisplayAlert(Languages.Notification, responseDTO.Message, Languages.Accept);

                this.IsRunning = false;
                this.IsEnabled = true;

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert(Languages.Notification, ex.Message, Languages.Accept);
            }
        }
        #endregion

        #region Constructor
        public ChangePasswordViewModel()
        {
            this.IsEnabled = true;
            this.IsRunning = false;

            this._apiService = new ApiService();
            this.GetUserCommand = new Command(GetUser);
            this.ChangePasswordCommand = new Command(ChangePasswordUser);
        }
        #endregion
    }
}
