package edu.sharif.ce.data_collector.exchange;

import edu.sharif.ce.data_collector.model.TickerPrice;

import java.util.List;

public interface ExchangeApi {
    List<TickerPrice> getAllPrices();
}
