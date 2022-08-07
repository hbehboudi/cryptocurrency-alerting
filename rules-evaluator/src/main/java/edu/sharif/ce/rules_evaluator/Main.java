package edu.sharif.ce.rules_evaluator;

import edu.sharif.ce.rules_evaluator.consumer.Consumer;
import edu.sharif.ce.rules_evaluator.evaluator.Evaluator;

public class Main {

    public static void main(String[] args) throws InterruptedException {
        new Consumer().start();
        Thread.sleep(5_000);
        new Evaluator().start();
    }
}
