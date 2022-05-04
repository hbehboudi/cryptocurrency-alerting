package edu.sharif.ce.rules_evaluator;

import edu.sharif.ce.rules_evaluator.consumer.Consumer;
import edu.sharif.ce.rules_evaluator.evaluator.Evaluator;

public class Main {

    public static void main(String[] args) {
        new Consumer().start();
        new Evaluator().start();
    }
}
