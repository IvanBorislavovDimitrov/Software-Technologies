const Task = require('../models/Task');

module.exports = {
    index: (req, res) => {
        Task.find().then(tasks => {
            res.render('task/index', {'tasks': tasks});
        });
    },

    createGet: (req, res) => {
        res.render('task/create');
    },

    createPost: (req, res) => {
        let task = req.body;
        Task.create(task).then(task => {
            res.redirect("/");
        }).catch(err => {
            task.error = 'Cannot create task.';
            res.render('task/create', task);
        });
    },

	deleteGet: (req, res) => {
        let filmId = req.params.id;
        Task.findById(filmId).then(task => {
            if (task) {
                return res.render('task/delete', task);
            }
            else {
                return res.redirect('/');
            }
        }).catch(err => res.redirect('/'));
    },

	deletePost: (req, res) => {
        let filmId = req.params.id;
        Task.findByIdAndRemove(filmId).then(task => {
            res.redirect('/');
        }).catch(err => res.redirect('/'));
    }
};