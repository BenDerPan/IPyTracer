"""
    
    This file comes from the project RevitPythonWrapper, written by Gui Talarico
    https://github.com/gtalarico

    I used this logger to start the project without spending hours to setup a new one.
    Many thanks to Gui Talarico for providing ready-to-use tools!

    
"""
import sys

class mockLoggerWrapper():
    def __init__(*args, **kwargs):
        pass

    def __getattr__(self, *args, **kwargs):
        return mockLoggerWrapper(*args, **kwargs)

    def __call__(self, *args, **kwargs):
        pass


class LoggerWrapper():
    """ Logger Wrapper to extend loggers functionality.
    Usage:
     from logger import LoggerWrapper
     logger = LoggerWrapper()  #  Initialized loger
    Same calls as regular logger:
     logger.info('Message')
     >> [INFO]  Message
     logger.debug('Message')
     >> [DEBUG]  Message
    Set Logging Level/Debug:
     logger.verbose(True)  # Set to Info or higher as default
    Additional Features:
     logger.title('Message'): Outputs lines above and below, uses clean format
     >> =========
     >> Message
     >> =========
     logger.error('Message'): appends errmsg to self.errors.
                              This allows you to check if an error occured,
                              and if it did not, close console window.
     >> [ERROR]  Message
     print(logger.errors)
     >> ['Message']
    # Hides windows if not errors have occured.
     if not logger.errors:
        __window__.Close()
    """

    def __init__(self):

        handler = logging.StreamHandler(sys.stdout)
        formatter = logging.Formatter("[%(levelname)s] %(message)s")
        handler.setFormatter(formatter)

        logger = logging.getLogger('iph_logger')
        logger.addHandler(handler)
        logger.setLevel(logging.INFO)

        handler_title = logging.StreamHandler(sys.stdout)
        formatter_title = logging.Formatter("%(message)s")
        handler_title.setFormatter(formatter_title)

        logger_title = logging.getLogger('logger_title')
        logger_title.addHandler(handler_title)
        logger_title.setLevel(logging.INFO)

        self._logger = logger
        self._logger_title = logger_title
        self.errors = []

    def disable(self):
        self._logger.setLevel(logging.CRITICAL)

    def verbose(self, verbose):
        if verbose:
            self._logger.setLevel(logging.DEBUG)
        else:
            self._logger.setLevel(logging.INFO)

    def title(self, msg):
        print('=' * 60)
        self._logger_title.info(msg)
        print('=' * 60)

    def info(self, msg):
        self._logger.info(msg)

    def debug(self, msg):
        self._logger.debug(msg)

    def warning(self, msg):
        self._logger.warning(msg)

    def error(self, msg):
        self._logger.error(msg)
        self.errors.append(msg)

    def critical(self, msg):
        self._logger.critical(msg)

    def setLevel(self, level):
        self._logger.setLevel(level)


try:
    import logging
except ImportError:
    # In Dynamo, Use Mock Logger
    logger = mockLoggerWrapper()
else:
    # In PyRevit, Use Logger
    logger = LoggerWrapper()
