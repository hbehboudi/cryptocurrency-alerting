package edu.sharif.ce.rules_evaluator;

import edu.sharif.ce.commons.model.PriceType;
import edu.sharif.ce.rules_evaluator.consumer.Consumer;
import edu.sharif.ce.rules_evaluator.evaluator.Evaluator;
import edu.sharif.ce.rules_evaluator.model.IndicatorType;
import edu.sharif.ce.rules_evaluator.model.Rule;

import java.util.ArrayList;

public class Main {
    public static void main(String[] args) {
        startConsumer();
        startEvaluator();
    }

    private static void startConsumer() {
        var consumer = new Consumer();
        consumer.start();
    }

    private static void startEvaluator() {
        var rules = new ArrayList<Rule>();
        rules.add(new Rule("ETHBTC", PriceType.CLOSE, PriceType.CLOSE, 25, 50, IndicatorType.SMA));
        Evaluator evaluator = new Evaluator(rules);
        evaluator.start();
    }
}
