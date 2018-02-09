const Report = require('../models/Report');
module.exports = {
    index: (req, res) => {
        Report.find().then(reports => {
            res.render('report/index', {'reports': reports});
        });
    },
    createGet: (req, res) => {
        res.render('report/create');
    },
    createPost: (req, res) => {
        let report = req.body;
        Report.create(report).then(report => {
            res.redirect('/');
        }).catch(err => {
            report.error = 'Cannot create report!';
            res.render('report/create', report);
            console.log(err);
        });
    },
    detailsGet: (req, res) => {
        let reportId = req.params.id;
        Report.findById(reportId).then(report => {
            res.render('report/details', report);
        }).catch(err => res.redirect('/'));
    },
    deleteGet: (req, res) => {
        let reportId = req.params.id;
        Report.findById(reportId).then(report => {
            res.render('report/delete', report);
        }).catch(err => res.redirect('/'));
    },
    deletePost: (req, res) => {
        let reportId = req.params.id;
        Report.findByIdAndRemove(reportId).then(report => {
            res.redirect('/');
        }).catch(err => res.redirect('/'));
    }
};