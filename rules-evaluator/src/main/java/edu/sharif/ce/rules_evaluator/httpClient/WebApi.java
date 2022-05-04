package edu.sharif.ce.rules_evaluator.httpClient;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import edu.sharif.ce.commons.model.PriceType;
import edu.sharif.ce.rules_evaluator.model.Alert;
import edu.sharif.ce.rules_evaluator.model.IndicatorType;
import edu.sharif.ce.rules_evaluator.model.Rule;

import java.io.IOException;
import java.net.URI;
import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.List;
import java.util.stream.Collectors;

public class WebApi {

    private static final WebApi instance = new WebApi();

    private WebApi() {
    }

    public static WebApi getInstance() {
        return instance;
    }

    private final String API_URL = "http://localhost:8000/api/RuleEvaluator";

    public List<Rule> getRules() throws IOException, InterruptedException {
        var httpClient = HttpClient.newHttpClient();
        var request = HttpRequest.newBuilder()
                .method("GET", HttpRequest.BodyPublishers.ofString("{\"Secretkey\": \"SyXzAxDTso\"}"))
                .header("Content-Type", "application/json")
                .uri(URI.create(API_URL))
                .build();

        var response = httpClient.send(request, HttpResponse.BodyHandlers.ofString());
        ResultDto resultDtos = new ObjectMapper().readValue(response.body(), new TypeReference<ResultDto>() {
        });

        return resultDtos.data.ruleDtos.stream().map(this::convertToRule).collect(Collectors.toList());
    }

    public void addAlert(Alert alert) throws Exception {
        var httpClient = HttpClient.newHttpClient();
        var request = HttpRequest.newBuilder()
                .method("POST", HttpRequest.BodyPublishers.ofString(
                        String.format("{\"Secretkey\": \"SyXzAxDTso\", \"RuleId\": %d, \"Price\": %s, \"Time\": %d}",
                                alert.getRuleId(),
                                alert.getCandlestick().getPrice(PriceType.CLOSE),
                                alert.getCandlestick().getCloseTime())))
                .header("Content-Type", "application/json")
                .uri(URI.create(API_URL))
                .build();

        var response = httpClient.send(request, HttpResponse.BodyHandlers.ofString());
        ResultDto resultDtos = new ObjectMapper().readValue(response.body(), new TypeReference<ResultDto>() {
        });

        if (resultDtos.isSuccess) {
            throw new Exception();
        }
    }

    private Rule convertToRule(RuleDto ruleDto) {
        var shortPriceType = PriceType.valueOf(ruleDto.getLessPriceType().toUpperCase());
        var longPriceType = PriceType.valueOf(ruleDto.getMorePriceType().toUpperCase());
        var indicatorType = IndicatorType.valueOf(ruleDto.getIndicator());

        return new Rule(ruleDto.getId(), ruleDto.getSymbol(), shortPriceType, longPriceType,
                ruleDto.getLessPeriod(), ruleDto.getMorePeriod(), indicatorType);
    }
}
