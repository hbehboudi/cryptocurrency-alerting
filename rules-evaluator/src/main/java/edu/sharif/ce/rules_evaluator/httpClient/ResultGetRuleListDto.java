package edu.sharif.ce.rules_evaluator.httpClient;

import java.util.List;

public class ResultGetRuleListDto {

    public List<RuleDto> ruleDtos;

    public int rowsCount;

    public List<RuleDto> getResultGetRuleDtos() {
        return ruleDtos;
    }

    public void setResultGetRuleDtos(List<RuleDto> ruleDtos) {
        this.ruleDtos = ruleDtos;
    }

    public int getRowsCount() {
        return rowsCount;
    }

    public void setRowsCount(int rowsCount) {
        this.rowsCount = rowsCount;
    }
}
