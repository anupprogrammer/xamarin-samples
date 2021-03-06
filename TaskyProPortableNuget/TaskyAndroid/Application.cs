﻿using System;
using System.Collections.Generic;
using System.Text;
using Android.App;
using Tasky.BL.Managers;
using SQLite.Net;
using System.IO;

namespace TaskyAndroid {
    [Application]
    public class TaskyApp : Application {
        public static TaskyApp Current { get; private set; }

        public TaskManager TaskMgr { get; set; }
        SQLiteConnection conn;

        public TaskyApp(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
            : base(handle, transfer) {
                Current = this;
        }

        public override void OnCreate()
        {
            base.OnCreate();

            var sqliteFilename = "TaskDB.db3";
            string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(libraryPath, sqliteFilename);
            var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            conn = new SQLiteConnection(plat,path);

            TaskMgr = new TaskManager(conn);
        }
    }
}
