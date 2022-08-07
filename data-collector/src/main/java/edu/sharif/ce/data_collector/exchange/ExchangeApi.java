package edu.sharif.ce.data_collector.exchange;

import com.binance.api.client.domain.market.CandlestickInterval;
import edu.sharif.ce.commons.model.Candlestick;

import java.util.List;

public interface ExchangeApi {

    List<Candlestick> getCandlestickBars(String symbol, CandlestickInterval interval);
}
