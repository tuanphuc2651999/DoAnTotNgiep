using Liz.DoAn.Resource;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Liz.DoAn
{
    public class GMail
    {
        private string _sender = string.Empty;
        private string _from = string.Empty;
        private string _to = string.Empty;
        private string _cc = string.Empty;
        private string _bcc = string.Empty;
        private string _subject = string.Empty;
        private string _body = string.Empty;
        private bool _isHTMLBody = true;
        private bool _isEnableSSL = false;
        private Encoding _endCode = Encoding.UTF8;
        private Attachment _attachment = null;
        private List<Attachment> _attList = null;
        public string Sender
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_sender))
                {
                    _sender = ConfigurationManager.AppSettings["MAIL_SENDER"];
                }
                if (string.IsNullOrWhiteSpace(_sender))
                {
                    _sender = LizSetting.MAIL_SENDER;
                }

                return _sender;
            }
            set
            {
                _sender = value;
            }
        }
        public string From
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_from))
                {
                    _from = ConfigurationManager.AppSettings["MAIL_FROM"];
                }

                if (string.IsNullOrWhiteSpace(_from))
                {
                    _from = LizSetting.MAIL_FROM;
                }

                return _from;
            }
            set
            {
                _from = value;
            }
        }
        public string Subject
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_subject))
                {
                    _subject = ConfigurationManager.AppSettings["MAIL_SUBJECT"];
                }

                if (string.IsNullOrWhiteSpace(_subject))
                {
                    _subject = LizSetting.MAIL_SUBJECT;
                }

                return _subject;
            }
            set
            {
                _subject = value;
            }
        }
        public string Body
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_body))
                {
                    _body = ConfigurationManager.AppSettings["MAIL_BODY"];
                }

                if (string.IsNullOrWhiteSpace(_body))
                {
                    _body = LizSetting.MAIL_BODY;
                }

                return _body;
            }
            set
            {
                _body = value;
            }
        }
        public string To
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_to))
                {
                    _to = ConfigurationManager.AppSettings["MAIL_TO"];
                }

                if (string.IsNullOrWhiteSpace(_to))
                {
                    _to = LizSetting.MAIL_TO;
                }

                return _to;
            }
            set
            {
                _to = value;
            }
        }

        public string CC
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_cc))
                {
                    _cc = ConfigurationManager.AppSettings["MAIL_CC"];
                }

                if (string.IsNullOrWhiteSpace(_cc))
                {
                    _cc = LizSetting.MAIL_CC;
                }

                return _cc;
            }
            set
            {
                _cc = value;
            }
        }

        public string BCC
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_bcc))
                {
                    _bcc = ConfigurationManager.AppSettings["MAIL_BCC"];
                }

                if (string.IsNullOrWhiteSpace(_bcc))
                {
                    _bcc = LizSetting.MAIL_BCC;
                }

                return _bcc;
            }
            set
            {
                _bcc = value;
            }
        }
        public bool IsHTMLBody
        {
            get
            {
                _isHTMLBody = true;
                return _isHTMLBody;
            }
            set
            {
                _isHTMLBody = value;
            }
        }
        public Attachment AttachmentFile
        {
            get
            {
                return _attachment;
            }
            set
            {
                _attachment = value;
            }
        }

        public List<Attachment> Attachments
        {
            get
            {
                return _attList;
            }
            set
            {
                _attList = value;
            }
        }
        public void Send()
        {
            using (MailMessage mm = new MailMessage())
            {
                mm.From = new MailAddress(this.From, this.Sender);

                string[] tos = this.To.Split(new string[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries);
                for (int toIndex = 0; toIndex < tos.Length; toIndex++)
                {
                    string to = tos[toIndex];
                    if (to != string.Empty)
                    {
                        mm.To.Add(to);
                    }
                }

                if (!string.IsNullOrEmpty(this.CC))
                {
                    string[] ccs = this.CC.Split(new string[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int ccIndex = 0; ccIndex < ccs.Length; ccIndex++)
                    {
                        string cc = ccs[ccIndex];
                        if (cc != string.Empty)
                        {
                            mm.CC.Add(cc);
                        }
                    }
                }

                if (!string.IsNullOrEmpty(this.BCC))
                {
                    string[] bccs = this.BCC.Split(new string[] { ",", ";", " " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int bccIndex = 0; bccIndex < bccs.Length; bccIndex++)
                    {
                        string bcc = bccs[bccIndex];
                        if (bcc != string.Empty)
                        {
                            mm.Bcc.Add(bcc);
                        }
                    }
                }

                if (this.AttachmentFile != null)
                {
                    mm.Attachments.Add(this.AttachmentFile);
                }

                if (this.Attachments != null)
                {
                    for (int attIndex = 0; attIndex < this.Attachments.Count; attIndex++)
                    {
                        mm.Attachments.Add(this.Attachments[attIndex]);
                    }
                }

                mm.Subject = this.Subject;
                mm.SubjectEncoding = Encoding.UTF8;

                mm.Body = this.Body;
                if (string.IsNullOrWhiteSpace(this.Body))
                {
                    mm.Body = LizSetting.MAIL_MASTER_TEMPLATE;
                }

                string mail_content = mm.Body;
                if (!string.IsNullOrWhiteSpace(mail_content))
                {
                    mail_content = mail_content.Replace("{_title_}", this.Subject);
                    mail_content = mail_content.Replace("{_email_}", this.To);
                    mail_content = mail_content.Replace("{_body_}", this.Body);
                    mail_content = mail_content.Replace("{_application_name_}", this.Sender);
                    mm.Body = mail_content;
                }

                mm.IsBodyHtml = _isHTMLBody;

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;                   
                    string username = LizSetting.USER_EMAIL;
                    string password = LizSetting.PASSWORD_EMAIL;
                    NetworkCredential NetworkCred = new NetworkCredential(username, password);
                    //smtp.UseDefaultCredentials = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;

                    if (!string.IsNullOrWhiteSpace(this.From)
                        && !string.IsNullOrWhiteSpace(this.To))
                    {
                        smtp.Send(mm);
                    }
                }
            }
        }

        public void GuiEmailTaiKhoan(string guiToiEmail,string tenNguoiNhan, string taiKhoan, string matkhau)
        {
            bool isGmailSmtp = true;
            if (isGmailSmtp)
            {
                GMail m = new GMail();
                m.Sender = LizSetting.MAIL_SENDER;//Ai gửi
                m.To = guiToiEmail;
                m.Subject = LizSetting.MAIL_SUBJECT_TAIKHOANMOI;
                string body = LizSetting.MAIL_BODY_MATKHAUMOI;
                body = body.Replace("{_Tên_}", tenNguoiNhan);
                body = body.Replace("{_Email_}", guiToiEmail);
                body = body.Replace("{_Tài khoản_}", taiKhoan);
                body = body.Replace("{_Mật khẩu_}", matkhau);
                m.Body = body;
                m.IsHTMLBody = true;

                m.Send();
            }

        }
        public void GuiEmailTaiKhoanKH(string guiToiEmail, string tenNguoiNhan, string taiKhoan, string matkhau)
        {
            bool isGmailSmtp = true;
            if (isGmailSmtp)
            {
                GMail m = new GMail();
                m.Sender = LizSetting.MAIL_SENDER;//Ai gửi
                m.To = guiToiEmail;
                m.Subject = LizSetting.MAIL_SUBJECT_TAIKHOANMOI;
                string body = LizSetting.MAIL_BODY_TAIKHOANKHACHHANG;
                body = body.Replace("{_Tên_}", tenNguoiNhan);
                body = body.Replace("{_Email_}", guiToiEmail);
                body = body.Replace("{_Tài khoản_}", taiKhoan);
                body = body.Replace("{_Mật khẩu_}", matkhau);
                m.Body = body;
                m.IsHTMLBody = true;

                m.Send();
            }

        }


    }
}
