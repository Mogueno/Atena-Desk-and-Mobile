﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MobileTCC.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPageApp : TabbedPage
    {
        public MainPageApp()
        {
            InitializeComponent();
        }
       
    }
}