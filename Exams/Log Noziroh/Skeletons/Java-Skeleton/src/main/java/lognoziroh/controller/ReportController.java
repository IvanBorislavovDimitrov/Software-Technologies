package lognoziroh.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import lognoziroh.bindingModel.ReportBindingModel;
import lognoziroh.repository.ReportRepository;
import lognoziroh.entity.Report;

import java.util.List;

@Controller
public class ReportController {
	private final ReportRepository reportRepository;

	@Autowired
	public ReportController(ReportRepository reportRepository) {
		this.reportRepository = reportRepository;
	}

	@GetMapping("/")
	public String index(Model model) {
		List<Report> reports = this.reportRepository.findAll();
		model.addAttribute("view", "report/index");
		model.addAttribute("reports", reports);

		return "base-layout";
	}

	@GetMapping("/details/{id}")
	public String details(Model model, @PathVariable int id) {
		Report report = this.reportRepository.findOne(id);
		if (report != null) {
			model.addAttribute("view", "report/details");
			model.addAttribute("report", report);
			return "base-layout";
		}

		return "redirect:/";
	}

	@GetMapping("/create")
	public String create(Model model) {
		model.addAttribute("view", "report/create");

		return "base-layout";
	}

	@PostMapping("/create")
	public String createProcess(Model model, ReportBindingModel reportBindingModel) {
		model.addAttribute("view", "report/create");
		Report report = new Report(reportBindingModel.getStatus(), reportBindingModel.getMessage(),
				reportBindingModel.getOrigin());

		this.reportRepository.saveAndFlush(report);

		return "redirect:/";
	}

	@GetMapping("/delete/{id}")
	public String delete(Model model, @PathVariable int id) {
		model.addAttribute("view", "report/delete");
		Report report = this.reportRepository.findOne(id);
		if (report != null) {
			model.addAttribute("report", report);
			return "base-layout";
		}

		return "redirect:/";
	}

	@PostMapping("/delete/{id}")
	public String deleteProcess(@PathVariable int id, ReportBindingModel reportBindingModel) {
		Report report = this.reportRepository.findOne(id);
		this.reportRepository.delete(report);
		return "redirect:/";
	}
}
