source("R/functions.R")



#'Return forecast values from Trading Economics API
#'@export getForecastData
#'
#'@param country string or list.
#'String to get data for one country. List of strings to get data for
#'several countries. For example, country = c('United States', 'Australia').
#'@param indicator string or list.
#'String  to get data for one category. List of strings to get data for several calendar events.
#'For example, category = 'GDP Growth Rate' or
#'category = c('Exports', 'Imports').
#'@param outType string.
#''df' for data frame,
#''lst'(default) for list .
#'
#'@return Return a list or dataframe of forecast values by country, by indicator, by country and indicator.
#'@section Notes:
#'At least one of parameters, country or indicator, should be provided.
#'Without credentials, only sample data is returned.
#' @seealso \code{\link{getMarketsData}}, \code{\link{getIndicatorData}}, \code{\link{getHistoricalData}} and \code{\link{getCalendarData}}
#'@examples
#'\dontrun{ getForecastData(country = 'United States', indicator = 'Imports')
#'getForecastData(country = c('United States', 'India'), indicator = c('Imports','Exports'))
#'}


getForecastData <- function(country = NULL, indicator = NULL, outType = NULL){
  base <- "https://api.tradingeconomics.com/forecast"

  df_final = data.frame()
  step = 10

  for(i in seq(1, length(country), by = step)){

    init = as.numeric(i)
    finit = as.numeric(i)+step-1

    if (is.null(country) & is.null(indicator)){
      stop('At least one of parameters, country or indicator, should be indicated. ')
    } else if (is.null(country) & !is.null(indicator)){
      url <- paste(base, 'indicator',
                   paste(indicator, collapse = ','), sep = '/')
    } else if (!is.null(country) & is.null(indicator)){
      url <- paste(base, 'country',
                   paste(na.omit(country[init:finit]), collapse = ','), sep = '/')
    } else {
      url <- paste(base, 'country', paste(na.omit(country[init:finit]), collapse = ','), 'indicator',
                   paste(indicator, collapse = ','), sep = '/')
    }

    url <- paste(url, '?c=', apiKey, sep = '')
    url <- URLencode(url)
    request <- GET(url)

    checkRequestStatus(http_status(request)$message)

    webResults <- do.call(rbind.data.frame, checkForNull(content(request)))

    df_final = rbind(df_final, webResults)
    Sys.sleep(0.5)
  }

  if (is.null(outType)| identical(outType, 'lst')){
    df_final <- split(df_final , f = df_final$Country)
  } else if (identical(outType, 'df')){
    df_final = df_final
  } else {
    stop('output_type options : df for data frame, lst(default) for list by country ')
  }

  return(df_final)
}




