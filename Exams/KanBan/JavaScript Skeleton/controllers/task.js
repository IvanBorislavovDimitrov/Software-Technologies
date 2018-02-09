const Task = require('../models/Task');

module.exports = {
	index: (req, res) => {
        let allTasks = Task.find().then(tasks => {
            let openTasks = tasks.filter(x => x.status === "Open");
            let inProgressTasks = tasks.filter(x => x.status === "In Progress");
            let finishedTasks = tasks.filter(x => x.status === "Finished");

            res.render('task/index', {
                'openTasks': openTasks,
                'inProgressTasks': inProgressTasks,
                'finishedTasks': finishedTasks,
            });
        })
	},
	createGet: (req, res) => {
		res.render('task/create');
	},
	createPost: (req, res) => {
        let task = req.body;
        Task.create(task).then(task => {
            res.redirect('/');
        }).catch(err => {
            task.error = 'Cannot create task.';
            res.render('task/create', task);
        });
	},
	editGet: (req, res) => {
	    let taskId = req.params.id;

	    Task.findById(taskId).then(task => {
	        res.render('task/edit', task);
        })
	},
	editPost: (req, res) => {
        let task = req.body;
        let taskId = req.params.id;

        Task.findByIdAndUpdate(taskId, task).then(tasks => {
            res.redirect("/");
        }).catch(err => {
            task.id = taskId;
            task.error = "Cannot edit task.";
            return res.render("task/edit", task);
        });
    }
};