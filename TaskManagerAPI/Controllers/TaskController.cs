using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManagerAPI.Models;
using TaskManagerAPI.Business;

namespace TaskManagerAPI.Controllers
{    
    public class TaskController : ApiController
    {
        private TaskDomain TaskDom = new TaskDomain();
        // GET: api/Task
        [HttpGet]
        public IList<TaskModel> GetTasks()
        {
            return TaskDom.GetAllTasks();
        }

        // GET: api/Task/5
        [HttpGet]
        public TaskModel GetTaskDetails(int id)
        {
            return TaskDom.GetTaskDetails(id);
        }

        // POST: api/Task
        [HttpPost]
        [ResponseType(typeof(void))]
        public void SaveTask(TaskModel value)
        {
            TaskDom.SaveTask(value);

            //return CreatedAtRoute("DefaultApi", new { id = value.TaskID },value);
           // return StatusCode(HttpStatusCode.NoContent);
        }

        // PUT: api/Task/5
        [HttpPut]
        public void UpdateTask(TaskModel value)
        {
            TaskDom.UpdateTask(value.TaskID, value);
        }

        // DELETE: api/Task/5
        [HttpDelete]
        public void DeleteTask(int id)
        {
            TaskDom.DeleteTask(id);

        }

        [HttpPut]        
        public void EndTask(int id)
        {
            TaskDom.EndTask(id);
           // return  StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        public List<TaskModel> SerachTask(TaskModel task)
        {
            return TaskDom.SearchTasks(task);
        }

        [HttpGet]
        public List<ParentTaskModel> GetParentTasks()
        {
            return TaskDom.GetAllParentTasks();
        }


    }
}
