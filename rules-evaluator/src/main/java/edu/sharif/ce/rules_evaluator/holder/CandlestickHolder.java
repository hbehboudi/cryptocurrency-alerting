package edu.sharif.ce.rules_evaluator.holder;

import edu.sharif.ce.commons.config.Config;
import edu.sharif.ce.commons.model.Candlestick;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ConcurrentHashMap;
import java.util.stream.Collectors;

public class CandlestickHolder {

    private final ConcurrentHashMap<String, ConcurrentHashMap<String, ArrayList<Candlestick>>> candlesticks = new ConcurrentHashMap<>();
    private final ConcurrentHashMap<String, ConcurrentHashMap<String, Long>> lastOpenTimes = new ConcurrentHashMap<>();

    private static final CandlestickHolder instance = new CandlestickHolder();

    private CandlestickHolder() {
        for (var symbol : Config.SYMBOLS) {
            var lastOpenTimeByTimeFrame = new ConcurrentHashMap<String, Long>();
            var candlesticksByTimeFrame = new ConcurrentHashMap<String, ArrayList<Candlestick>>();

            Config.TIME_FRAMES.forEach(x -> lastOpenTimeByTimeFrame.put(x, 0L));
            Config.TIME_FRAMES.forEach(x -> candlesticksByTimeFrame.put(x, new ArrayList<>()));

            lastOpenTimes.put(symbol, lastOpenTimeByTimeFrame);
            candlesticks.put(symbol, candlesticksByTimeFrame);
        }
    }

    public static CandlestickHolder getInstance() {
        return instance;
    }

    public synchronized void addCandlestick(Candlestick candlestick) {
        var symbol = candlestick.getSymbol();
        var openTime = candlestick.getOpenTime();
        var timeFrame = candlestick.getTimeFrame();

        var lastOpenTime = lastOpenTimes.get(symbol).get(timeFrame);

        if (openTime > lastOpenTime) {
            candlesticks.get(symbol).get(timeFrame).add(candlestick);
            lastOpenTimes.get(symbol).put(timeFrame, openTime);
        }
    }

    public synchronized List<Candlestick> getCandlesticks(String symbol, String timeFrame, long startTime) {
        return candlesticks.get(symbol).get(timeFrame)
                .stream()
                .filter(x -> x.getOpenTime() > startTime)
                .collect(Collectors.toList());
    }
}
