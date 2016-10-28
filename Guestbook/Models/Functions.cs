using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using log4net;
using log4net.Config;





namespace Guestbook.Models
{
    
    public class Functions
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Functions));
        
        private int a;
        private int b;
        private int c;

        public int A { get { return a; } set { value = a; } }
        public int B { get { return b; } set { value = b; } }

        public int GetSum(int A, int B)
        {
            try
            {
                c = A + B;
            }
            catch (Exception ex)
            {
                log.Debug(ex.Message);
                log.Debug(ex.StackTrace);
                log.Debug(ex.TargetSite);
            }
            return c;
        }

        public int GetMinus(int A, int B)
        {
            try
            {
                c = A - B;
            }
            catch (Exception ex)
            {
                log.Debug(ex.Message);
                log.Debug(ex.StackTrace);
                log.Debug(ex.TargetSite);
            }
            return c;
        }

        public int GetDerived(int A, int B)
        {
            
            try
            {
                c = A / B;
                
            }
            catch (Exception ex)
            {
                log.Debug(ex.Message);
                log.Debug(ex.StackTrace);
                log.Debug(ex.TargetSite);
            }
            return c;
        }

        public int GetMult(int A, int B)
        {
            try
            {
               c = A * B;
            }
            catch (Exception ex)
            {
                log.Debug(ex.Message);
                log.Debug(ex.StackTrace);
                log.Debug(ex.TargetSite);
            }
            return c;
        }
    }
}