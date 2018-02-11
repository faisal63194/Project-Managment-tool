using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using ProjectManagmentTool.DAL;
using ProjectManagmentTool.Models;

namespace ProjectManagmentTool.BLL
{
    public class CommentManager
    {
        CommentGatway commentGatway=new CommentGatway();

        public DataTable GetAllTask(int projectId)
        {
            return commentGatway.GetAllTask(projectId);
        }

        public int SaveComment(CommentModel comment)
        {
            return commentGatway.SaveComment(comment);
        }
    }
}