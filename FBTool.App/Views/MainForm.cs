using FBTool.BLL.Interface.Facebook;
using FBTool.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Telerik.WinControls.UI;

namespace FBTool.App.Views
{
    public partial class MainForm : RadForm
    {
        private List<IFacebookBussiness> _facebookBussinesses = new List<IFacebookBussiness>();

        public MainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Start();
        }


        private void Start()
        {
            var task = new Task(() =>
            {
                var facebookBussiness = Program.GetService<IFacebookBussiness>();
                _facebookBussinesses.Add(facebookBussiness);
                facebookBussiness.Login(new FacebookAccount { 
                    Username = "sdfs",
                    Password = "sdfsdf"
                });
            });
            task.Start();
        }

        private void MainForm_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            _facebookBussinesses.ForEach(_ =>
            {
                _.Close();
            });
            _facebookBussinesses.Clear();
        }
    }
}
