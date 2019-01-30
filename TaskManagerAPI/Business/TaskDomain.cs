using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerAPI.Models;
using TaskManagerAPI.Repository;

namespace TaskManagerAPI.Business
{
    public class TaskDomain
    {
        private TaskRepository TaskRep = new TaskRepository();
        public List<TaskModel> GetAllTasks()
        {
            List<Task> tasklist = TaskRep.GetAllTasks();

            List<TaskModel> modelList = new List<TaskModel>();
            foreach (Task item in tasklist)
            {
                var model = convertTasktoTaskModel(item);
                modelList.Add(model);
            }
            return modelList;
        }
        public TaskModel GetTaskDetails(int id)
        {
            TaskModel taskmodel = new TaskModel();
            Task task = TaskRep.GetTaskDetail(id);
            if (task != null)
            {
                taskmodel = convertTasktoTaskModel(task);
            }
            return taskmodel;

        }


        public void SaveTask(TaskModel value)
        {
            Task task = convertTaskModeltoTask(value);
            TaskRep.SaveTask(task);
        }


        public void UpdateTask(int id, TaskModel value)
        {
            Task task = convertTaskModeltoTask(value);
            TaskRep.UpdateTask(id, task);
        }
        public void DeleteTask(int id)
        {
            TaskRep.DeleteTask(id);
        }

        public void EndTask(int id)
        {
            TaskRep.EndTask(id);
            // return  StatusCode(HttpStatusCode.NoContent);
        }

        public List<TaskModel> SearchTasks(TaskModel value)
        {
            Task task = convertTaskModeltoTask(value);
            List<Task> tasklist = TaskRep.TaskSearch(task);

            List<TaskModel> modelList = new List<TaskModel>();
            foreach (Task item in tasklist)
            {
                var model = convertTasktoTaskModel(item);
                modelList.Add(model);
            }
            return modelList;
        }

        public List<ParentTaskModel> GetAllParentTasks()
        {
            List<ParentTaskModel> PTModelList = new List<ParentTaskModel>();
            List<ParentTask> PTList = TaskRep.GetAllParentTasks();

            if (PTList != null)
            {
                foreach(ParentTask pt in PTList)
                {
                    PTModelList.Add(convertPTasktoPTaskModel(pt));
                }
            }
            return PTModelList;
        }


        private TaskModel convertTasktoTaskModel(Task task)
        {
            TaskModel taskModel = new TaskModel();

            taskModel.TaskID = task.Task_ID;
            taskModel.TaskName = task.Task1;
            taskModel.ParentTaskID = task.Parent_ID;
            taskModel.ParentTaskName = task.ParentTask.Parent_Task;
            taskModel.Priority = task.Priority ?? 0;
            taskModel.IsCompleted = task.IsCompleted ?? false;
            taskModel.StartDate = task.Start_Date ?? DateTime.Now;
            taskModel.EndDate = task.End_Date ?? DateTime.Now;

            return taskModel;
        }

        private Task convertTaskModeltoTask(TaskModel taskModel)
        {
            Task task = new Task();
            task.Task_ID = taskModel.TaskID;
            task.Task1 = taskModel.TaskName;
            task.Parent_ID = taskModel.ParentTaskID;
            task.Priority = taskModel.Priority;
            task.IsCompleted = taskModel.IsCompleted;
            task.Start_Date = taskModel.StartDate;
            task.End_Date = taskModel.EndDate;

            return task;
        }

        private ParentTaskModel convertPTasktoPTaskModel(ParentTask Ptask)
        {
            ParentTaskModel PTM = new ParentTaskModel();
            PTM.ParentTaskID = Ptask.Parent_ID;
            PTM.ParentTaskName = Ptask.Parent_Task;
            return PTM;
        }
    }
}