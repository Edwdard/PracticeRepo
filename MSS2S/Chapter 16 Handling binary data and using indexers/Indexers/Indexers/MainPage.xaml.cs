using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Indexers
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private PhoneBook phoneBook = new PhoneBook();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void findByNameClick(object sender, RoutedEventArgs e)
        {
            String text=name.Text;
            if (!String.IsNullOrEmpty(text))
            {
                Name personsName =  new Name(text);
                PhoneNumber personsPhoneNumber = this.phoneBook[personsName];
                phoneNumber.Text = String.IsNullOrEmpty(personsPhoneNumber.Text) ? "Not Found" : personsPhoneNumber.Text;
                //静态String方法IsNullOrEmpty是用来检查字符串为空或为null的好办法，如果符合条件则返回true,否则返回false
                //? :运算符“?:”运算符用于填充表单上电话号码框的“Text”属性的语句。请记住，此运算符类似于表达式的一个内联
                //if...else 语句。在前面的代码中，如果表达式“String.IsNullOrEmpty(personsPhoneNumber.Text)”为真，
                //则表示电话簿中未找到匹配项，并在表单上显示文本“未找到”；否则，将显示 personsPhoneNumber 变量的“Text”属
                //性中的值
            }
        }

        private void findByPhoneNumberClick(object sender, RoutedEventArgs e)
        {
            string text= phoneNumber.Text;
            if (!String.IsNullOrEmpty(text))
            {
               PhoneNumber personsPhoneNumber = new PhoneNumber(text);
                Name personsName = this.phoneBook[personsPhoneNumber];
                name.Text = String.IsNullOrEmpty(personsName.Text)?"Not Found":personsName.Text;

            }
        }

        private void addClick(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(name.Text) && !String.IsNullOrEmpty(phoneNumber.Text))
            {
                phoneBook.Add(new Name(name.Text),
                              new PhoneNumber(phoneNumber.Text));
                name.Text = "";
                phoneNumber.Text = "";
            }
        }
    }
}
