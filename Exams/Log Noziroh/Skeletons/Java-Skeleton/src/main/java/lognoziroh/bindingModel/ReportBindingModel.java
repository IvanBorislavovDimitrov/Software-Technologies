package lognoziroh.bindingModel;

import javax.persistence.Column;

public class ReportBindingModel {

    public ReportBindingModel() { }

    public void setStatus(String status) {
        this.status = status;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public void setOrigin(String origin) {
        this.origin = origin;
    }

    public ReportBindingModel(String status, String message, String origin) {
        this.status = status;
        this.message = message;

        this.origin = origin;
    }

    @Column(nullable = false)
    private String status;

    @Column(nullable = false)
    private String message;

    @Column(nullable = false)
    private String origin;

    public String getStatus() {
        return status;
    }

    public String getMessage() {
        return message;
    }

    public String getOrigin() {
        return origin;
    }
}
