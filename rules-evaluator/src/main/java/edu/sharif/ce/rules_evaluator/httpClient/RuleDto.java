package edu.sharif.ce.rules_evaluator.httpClient;

public class RuleDto {

    private long id;

    private String owner;

    private String name;

    private String symbol;

    private String description;

    private String indicator;

    private String morePriceType;

    private String lessPriceType;

    private int morePeriod;

    private int lessPeriod;

    public long getId() {
        return id;
    }

    public void setId(long id) {
        this.id = id;
    }

    public String getOwner() {
        return owner;
    }

    public void setOwner(String owner) {
        this.owner = owner;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getSymbol() {
        return symbol;
    }

    public void setSymbol(String symbol) {
        this.symbol = symbol;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }

    public String getIndicator() {
        return indicator;
    }

    public void setIndicator(String indicator) {
        this.indicator = indicator;
    }

    public String getMorePriceType() {
        return morePriceType;
    }

    public void setMorePriceType(String morePriceType) {
        this.morePriceType = morePriceType;
    }

    public String getLessPriceType() {
        return lessPriceType;
    }

    public void setLessPriceType(String lessPriceType) {
        this.lessPriceType = lessPriceType;
    }

    public int getMorePeriod() {
        return morePeriod;
    }

    public void setMorePeriod(int morePeriod) {
        this.morePeriod = morePeriod;
    }

    public int getLessPeriod() {
        return lessPeriod;
    }

    public void setLessPeriod(int lessPeriod) {
        this.lessPeriod = lessPeriod;
    }
}
