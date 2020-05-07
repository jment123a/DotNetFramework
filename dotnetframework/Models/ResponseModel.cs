using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetframework.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
        }

        public ResponseModel(string _msg)
        {
            success = false;
            msg = _msg;
        }
        public ResponseModel(bool _success, string _msg)
        {
            success = _success;
            msg = _msg;
        }

        public ResponseModel(object _obj)
        {
            success = true;
            data = _obj;
        }


        public bool success { get; set; } = true;
        public string msg { get; set; } = "";
        public object data { get; set; } = null;

    }
}
