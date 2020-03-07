using System;
using System.Windows.Forms;
using BlocklyPro.Models;
using BlocklyPro.ServiceRepository;
using BlocklyPro.Utility;

namespace BlocklyPro
{
    public partial class FrmLogin : Form
    {
        private readonly IGameServiceRepository _gameServiceRepository;
        public IIdentityServiceRepository _identityServiceRepository { get; }
        public FrmLogin(IIdentityServiceRepository identityServiceRepository,
            IGameServiceRepository gameServiceRepository)
        {
            _gameServiceRepository = gameServiceRepository;
            _identityServiceRepository = identityServiceRepository;
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtEmail.Text.IsValiedEmail())
                {
                    MessageBox.Show("Email is not valid one");
                    return;
                }

                var token = new TokenModel();
                if (btnLogin.Text.Equals("LOGIN"))
                {
                    token = await _identityServiceRepository.Login(new Request<LoginModel>(new LoginModel
                    {
                        Email = txtEmail.Text.Trim(),
                        Password = txtPassword.Text
                    }));
                }
                else if (btnLogin.Text.Equals("REGISTER"))
                {
                    token = await _identityServiceRepository.Register(new Request<RegisterModel>(new RegisterModel
                    {
                        Email = txtEmail.Text.Trim(),
                        Password = txtPassword.Text,
                        Name = txtEmail.Text.Split('@')[0]
                    }));
                }
                else
                {
                    Helper.Info("Invalid argument");
                }

                if (token != null)
                {
                    GlobalConfig.Token = token.Token;
                    GlobalConfig.User = txtEmail.Text;
                    this.Hide();
                    var frm = new FrmParent(this, _gameServiceRepository);
                    frm.Show();
                }
            }
            catch (Exception exception)
            {
                new ExceptionHandler(exception);
            }

        }

        private void BtnRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (btnRegister.Text.Equals("TO REGISTER"))
                {
                    btnLogin.Text = "REGISTER";
                    btnRegister.Text = "TO LOGIN";
                }
                else
                {
                    btnLogin.Text = "LOGIN";
                    btnRegister.Text = "TO REGISTER";
                }
            }
            catch (Exception exception)
            {
                new ExceptionHandler(exception);
            }
        }
    }
}
