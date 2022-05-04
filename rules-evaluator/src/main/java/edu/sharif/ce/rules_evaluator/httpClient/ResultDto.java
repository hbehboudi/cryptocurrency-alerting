package edu.sharif.ce.rules_evaluator.httpClient;

public class ResultDto {

    public boolean isSuccess;

    public String message;

    public ResultGetRuleListDto data;

    public boolean isSuccess() {
        return isSuccess;
    }

    public void setSuccess(boolean success) {
        isSuccess = success;
    }

    public String getMessage() {
        return message;
    }

    public void setMessage(String message) {
        this.message = message;
    }

    public ResultGetRuleListDto getData() {
        return data;
    }

    public void setData(ResultGetRuleListDto data) {
        this.data = data;
    }
}
