package pl.zimowski.karty;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.util.Iterator;
import java.util.NoSuchElementException;

/**
 * NOTE: Functionally, this class duplicates features already available in
 * net.jcards.eval.HandWithSharedIterator, however, it is much faster in performing those same
 * functions therefore it should be used whenever possible.
 */

/**
 * @author  zima
 */
public class HandIterator implements Iterator<Long> {

    private static final Logger log = LoggerFactory.getLogger(HandIterator.class);

    int _i1, _i2, _i3, _i4, _i5, _i6, _i7;
    long _card1, _n2, _n3, _n4, _n5, _n6;

    boolean _hasNext = true;
    int _numberOfCards;

    long _count, _binomial;

    public HandIterator(int aNumberOfCards) {
        // We only support 0-7 cards
        if ((aNumberOfCards < 0) || (aNumberOfCards > 7)) {
            throw new ArgumentOutOfRangeException("this iterator only supports 0-7 cards");
        }

        _i1 = _i2 = _i3 = _i4 = _i5 = _i6 = _i7 = -2;
        _count = 1;

        _numberOfCards = aNumberOfCards;
        _binomial = PokerMath.binomial(HandEngine.NUMBER_OF_CARDS, aNumberOfCards);

        if (log.isTraceEnabled()) {
            log.trace("binomial: " + HandEngine.NUMBER_OF_CARDS + " choose " + _numberOfCards);
        }
    }

    @Override
    public boolean hasNext() {
        return _count <= _binomial;
    }

    @Override
    public Long next() {
        ++_count;

        switch (_numberOfCards) {
            case 7:
                return deckChoose7();

            case 6:
                return deckChoose6();

            case 5:
                return deckChoose5();

            case 4:
                return deckChoose4();

            case 3:
                return deckChoose3();

            case 2:
                if (_i1 < 0) {
                    _i1 = 0;
                }
                return HandEngine._twoCardTable[_i1++];

            case 1:
                if (_i1 < 0) {
                    _i1 = 0;
                }
                return HandEngine._cardMasksTable[_i1++];

            default:
                assert (false);
                return 0L;
        }
    }

    @Override
    public void remove() {
        // not implemented
        throw new UnsupportedOperationException();
    }

    /**
     * Evaluates all possible combinations of 7 cards from a typical card deck (usually 52 cards).
     *
     * @return  card mask representing a hand
     *
     * @throws  NoSuchElementException  when all items have been enumerated
     */
    private long deckChoose7() throws NoSuchElementException {
        if (_i1 < 0) {
            _i1 = HandEngine.NUMBER_OF_CARDS - 1;
        }
        while (_i1 >= 0) {
            if (_i2 < 0) {
                _card1 = HandEngine._cardMasksTable[_i1];
                _i2 = _i1-- - 1;
            }
            while (_i2 >= 0) {
                if (_i3 < 0) {
                    _n2 = _card1 | HandEngine._cardMasksTable[_i2];
                    _i3 = _i2-- - 1;
                }
                while (_i3 >= 0) {
                    if (_i4 < 0) {
                        _n3 = _n2 | HandEngine._cardMasksTable[_i3];
                        _i4 = _i3-- - 1;
                    }
                    while (_i4 >= 0) {
                        if (_i5 < 0) {
                            _n4 = _n3 | HandEngine._cardMasksTable[_i4];
                            _i5 = _i4-- - 1;
                        }
                        while (_i5 >= 0) {
                            if (_i6 < 0) {
                                _n5 = _n4 | HandEngine._cardMasksTable[_i5];
                                _i6 = _i5-- - 1;
                            }
                            while (_i6 >= 0) {
                                if (_i7 < 0) {
                                    _n6 = _n5 | HandEngine._cardMasksTable[_i6];
                                    _i7 = _i6-- - 1;
                                }
                                while (_i7 >= 0) {
                                    return _n6 | HandEngine._cardMasksTable[_i7--];
                                }
                            } // 6
                        } // 5
                    } // 4
                } // 3
            } // 2
        } // 1
        throw new NoSuchElementException();
    }

    private long deckChoose6() throws NoSuchElementException {
        if (_i1 < 0) {
            _i1 = HandEngine.NUMBER_OF_CARDS - 1;
        }
        while (_i1 >= 0) {
            if (_i2 < 0) {
                _card1 = HandEngine._cardMasksTable[_i1];
                _i2 = _i1-- - 1;
            }
            while (_i2 >= 0) {
                if (_i3 < 0) {
                    _n2 = _card1 | HandEngine._cardMasksTable[_i2];
                    _i3 = _i2-- - 1;
                }
                while (_i3 >= 0) {
                    if (_i4 < 0) {
                        _n3 = _n2 | HandEngine._cardMasksTable[_i3];
                        _i4 = _i3-- - 1;
                    }
                    while (_i4 >= 0) {
                        if (_i5 < 0) {
                            _n4 = _n3 | HandEngine._cardMasksTable[_i4];
                            _i5 = _i4-- - 1;
                        }
                        while (_i5 >= 0) {
                            if (_i6 < 0) {
                                _n5 = _n4 | HandEngine._cardMasksTable[_i5];
                                _i6 = _i5-- - 1;
                            }
                            while (_i6 >= 0) {
                                return _n5 | HandEngine._cardMasksTable[_i6--];
                            } // 6
                        } // 5
                    } // 4
                } // 3
            } // 2
        } // 1
        throw new NoSuchElementException();
    }

    private long deckChoose5() throws NoSuchElementException {
        if (_i1 < 0) {
            _i1 = HandEngine.NUMBER_OF_CARDS - 1;
        }
        while (_i1 >= 0) {
            if (_i2 < 0) {
                _card1 = HandEngine._cardMasksTable[_i1];
                _i2 = _i1-- - 1;
            }
            while (_i2 >= 0) {
                if (_i3 < 0) {
                    _n2 = _card1 | HandEngine._cardMasksTable[_i2];
                    _i3 = _i2-- - 1;
                }
                while (_i3 >= 0) {
                    if (_i4 < 0) {
                        _n3 = _n2 | HandEngine._cardMasksTable[_i3];
                        _i4 = _i3-- - 1;
                    }
                    while (_i4 >= 0) {
                        if (_i5 < 0) {
                            _n4 = _n3 | HandEngine._cardMasksTable[_i4];
                            _i5 = _i4-- - 1;
                        }
                        while (_i5 >= 0) {
                            return _n4 | HandEngine._cardMasksTable[_i5--];
                        } // 5
                    } // 4
                } // 3
            } // 2
        } // 1
        throw new NoSuchElementException();
    }

    private long deckChoose4() throws NoSuchElementException {
        if (_i1 < 0) {
            _i1 = HandEngine.NUMBER_OF_CARDS - 1;
        }
        while (_i1 >= 0) {
            if (_i2 < 0) {
                _card1 = HandEngine._cardMasksTable[_i1];
                _i2 = _i1-- - 1;
            }
            while (_i2 >= 0) {
                if (_i3 < 0) {
                    _n2 = _card1 | HandEngine._cardMasksTable[_i2];
                    _i3 = _i2-- - 1;
                }
                while (_i3 >= 0) {
                    if (_i4 < 0) {
                        _n3 = _n2 | HandEngine._cardMasksTable[_i3];
                        _i4 = _i3-- - 1;
                    }
                    while (_i4 >= 0) {
                        return _n3 | HandEngine._cardMasksTable[_i4--];
                    } // 4
                } // 3
            } // 2
        } // 1
        throw new NoSuchElementException();
    }

    private long deckChoose3() throws NoSuchElementException {
        if (_i1 < 0) {
            _i1 = HandEngine.NUMBER_OF_CARDS - 1;
        }
        while (_i1 >= 0) {
            if (_i2 < 0) {
                _card1 = HandEngine._cardMasksTable[_i1];
                _i2 = _i1-- - 1;
            }
            while (_i2 >= 0) {
                if (_i3 < 0) {
                    _n2 = _card1 | HandEngine._cardMasksTable[_i2];
                    _i3 = _i2-- - 1;
                }
                while (_i3 >= 0) {
                    return _n2 | HandEngine._cardMasksTable[_i3--];
                } // 3
            } // 2
        } // 1
        throw new NoSuchElementException();
    }
}
