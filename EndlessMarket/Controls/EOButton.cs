using EndlessMarket.Properties;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace EndlessMarket.Controls
{
    public enum ButtonType
    {
        None,
        Ok,
        Cancel,
        Add,
        Login,
        Delete,

        // custom gfx
        Account,
        Exit
    }

    public class EOButton : Button
    {
        private ButtonType _buttonType = ButtonType.None;

        [DefaultValue(ButtonType.None)]
        public ButtonType ButtonType
        {
            get
            {
                return _buttonType;
            }
            set
            {
                switch (value)
                {
                    case ButtonType.Ok:
                        base.Image = Resources.OkButton;
                        base.MouseEnter += (s, e) => { base.Image = Resources.OkButtonHover; };
                        base.MouseLeave += (s, e) => { base.Image = Resources.OkButton; };
                        break;

                    case ButtonType.Cancel:
                        base.Image = Resources.CancelButton;
                        base.MouseEnter += (s, e) => { base.Image = Resources.CancelButtonHover; };
                        base.MouseLeave += (s, e) => { base.Image = Resources.CancelButton; };
                        break;

                    case ButtonType.Add:
                        base.Image = Resources.AddButton;
                        base.MouseEnter += (s, e) => { base.Image = Resources.AddButtonHover; };
                        base.MouseLeave += (s, e) => { base.Image = Resources.AddButton; };
                        break;

                    case ButtonType.Login:
                        base.Image = Resources.LoginButton;
                        base.MouseEnter += (s, e) => { base.Image = Resources.LoginButtonHover; };
                        base.MouseLeave += (s, e) => { base.Image = Resources.LoginButton; };
                        break;

                    case ButtonType.Delete:
                        base.Image = Resources.DeleteButton;
                        base.MouseEnter += (s, e) => { base.Image = Resources.DeleteButtonHover; };
                        base.MouseLeave += (s, e) => { base.Image = Resources.DeleteButton; };
                        break;

                    case ButtonType.Account:
                        base.Image = Resources.AccountButton;
                        base.MouseEnter += (s, e) => { base.Image = Resources.AccountButtonHover; };
                        base.MouseLeave += (s, e) => { base.Image = Resources.AccountButton; };
                        break;

                    case ButtonType.Exit:
                        base.Image = Resources.ExitButton;
                        base.MouseEnter += (s, e) => { base.Image = Resources.ExitButtonHover; };
                        base.MouseLeave += (s, e) => { base.Image = Resources.ExitButton; };
                        break;
                }

                if (base.Image != null)
                {
                    base.Width = base.Image.Width + 2;
                    base.Height = base.Image.Height + 2;

                }
                _buttonType = value;
            }
        }

        public EOButton()
        {
            this.Text = "";
            this.FlatAppearance.BorderSize = 0;
            this.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
            this.FlatAppearance.MouseDownBackColor = Color.Transparent;
            this.FlatAppearance.MouseOverBackColor = Color.Transparent;
            this.FlatStyle = FlatStyle.Flat;
            this.BackColor = Color.Transparent;
        }
    }
}
