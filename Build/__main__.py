import os

import utils

if __name__ == "__main__":
    try:
        utils.releaseInit()
        utils.releaseCopy()
    except Exception as e:
        print(e)
