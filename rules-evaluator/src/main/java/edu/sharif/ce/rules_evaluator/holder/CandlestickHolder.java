package edu.sharif.ce.rules_evaluator.holder;

import edu.sharif.ce.commons.config.Config;
import edu.sharif.ce.commons.model.Candlestick;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ConcurrentHashMap;
import java.util.stream.Collectors;

public class CandlestickHolder {

    private final ConcurrentHashMap<String, ArrayList<Candlestick>> candlesticksBySymbol = new ConcurrentHashMap<>();
    private final ConcurrentHashMap<String, Long> lastOpenTimeBySymbol = new ConcurrentHashMap<>();

    private static final CandlestickHolder instance = new CandlestickHolder();

    private CandlestickHolder() {
        Config.SYMBOLS.forEach(x -> {
            candlesticksBySymbol.put(x, new ArrayList<>());
            lastOpenTimeBySymbol.put(x, 0L);
        });
    }

    public static CandlestickHolder getInstance() {
        return instance;
    }

    public synchronized void addCandlestick(Candlestick candlestick) {
        var symbol = candlestick.getSymbol();
        var openTime = candlestick.getOpenTime();
        var lastOpenTime = lastOpenTimeBySymbol.get(symbol);

        if (openTime > lastOpenTime) {
            candlesticksBySymbol.get(symbol).add(candlestick);
            lastOpenTimeBySymbol.put(symbol, openTime);
        }
    }

    public synchronized List<Candlestick> getCandlesticks(String symbol, long startTime) {
        return candlesticksBySymbol.get(symbol)
                .stream()
                .filter(x -> x.getOpenTime() > startTime)
                .collect(Collectors.toList());
    }
}
