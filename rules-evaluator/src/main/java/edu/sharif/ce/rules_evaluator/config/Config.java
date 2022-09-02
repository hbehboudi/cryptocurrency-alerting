package edu.sharif.ce.rules_evaluator.config;

public class Config extends edu.sharif.ce.commons.config.Config {

    public static final String CONSUMER_GROUP_ID = "cryptocurrency";
    public static final String AUTO_OFFSET_RESET = "earliest";
    public static final int CONSUMER_DELAY = 1_000;
    public static final int CONSUMER_TIMEOUT = 1_000;
}
