package pl.zimowski.karty;

import java.util.Iterator;
import java.util.NoSuchElementException;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

/**
 * @author zima
 */
public class HandIteratorEx implements Iterator<Long> {

	private static final Logger _log = LoggerFactory.getLogger(HandIteratorEx.class);

    int _i1, _i2, _i3, _i4, _i5, _i6, _i7, length;
    long _card1, _card2, _card3, _card4, _card5, _card6, _card7;
    long _n2, _n3, _n4, _n5, _n6;
    long shared, dead;

	boolean _hasNext = true;
	int _numberOfCards;
	long _count, _binomial;

	public HandIteratorEx(long aShared, long aDead, int aNumOfCards) {

		_numberOfCards = aNumOfCards;
		shared = aShared;
		dead = aDead;

		dead |= shared;
		_i1 = _i2 = _i3 = _i4 = _i5 = _i6 = _i7 = -2;
		_count = 1;

		int sharedBits = HandEngine.BitCount(aShared);
		int deadBits = HandEngine.BitCount(aDead);
		int n = HandEngine.NUMBER_OF_CARDS - (sharedBits + deadBits);
		int k = aNumOfCards - sharedBits;
		_binomial = PokerMath.binomial(n, k);
		if(_log.isTraceEnabled()) _log.trace("binomial: " + n + " choose " + k);
	}

	@Override
    public boolean hasNext() {
		return _count <= _binomial;
	}

	@Override
    public Long next() {

		++_count;

        switch (_numberOfCards - HandEngine.BitCount(shared))
        {
            case 7: return deckChoose7();
            case 6: return deckChoose6();
            case 5: return deckChoose5();
            case 4: return deckChoose4();
            case 3: return deckChoose3();
            case 2:
            	if(_i1 < 0) _i1 = 0;
            	do {
            		try { _card1 = HandEngine._twoCardTable[_i1++]; }
            		catch(ArrayIndexOutOfBoundsException aioobe) {}
            	}
            	while((dead & _card1) != 0);
                return _card1 | shared;
            case 1:
            	if(_i1 < 0) _i1 = 0;
            	do {
            		//try { _card1 = Hand.CardMasksTable[_i1++]; }
            		//catch(ArrayIndexOutOfBoundsException aioobe) {}
            		_card1 = HandEngine._cardMasksTable[_i1++];
            	}
            	while((dead & _card1) != 0);
                return _card1 | shared;
            case 0:
            	_i1 = 0;
                return shared;
            default:
            	_i1 = 0;
                return 0L;
        }
	}

	@Override
    public void remove() {
		// not implemented
		throw new UnsupportedOperationException();
	}

	private long deckChoose7() throws NoSuchElementException {
    	if(_i1 < 0) _i1 = HandEngine.NUMBER_OF_CARDS - 1;
        while(_i1 >= 0) {
        	if(_i2 < 0) {
	        	_card1 = HandEngine._cardMasksTable[_i1];
	            if((dead & _card1) != 0) {
	            	_i1--;
	            	continue;
	            }
	            _i2 = _i1-- - 1;
        	}
            while(_i2 >= 0) {
            	if(_i3 < 0) {
	            	_card2 = HandEngine._cardMasksTable[_i2];
	                if((dead & _card2) != 0) {
	                	_i2--;
	                	continue;
	                }
	                _n2 = _card1 | _card2;
	                _i3 = _i2-- - 1;
            	}
                while(_i3 >= 0) {
                	if(_i4 < 0) {
	                	_card3 = HandEngine._cardMasksTable[_i3];
	                    if((dead & _card3) != 0) {
	                    	_i3--;
	                    	continue;
	                    }
	                    _n3 = _n2 | _card3;
	                    _i4 = _i3-- - 1;
                	}
                    while(_i4 >= 0) {
                    	if(_i5 < 0) {
	                    	_card4 = HandEngine._cardMasksTable[_i4];
	                        if((dead & _card4) != 0) {
	                        	_i4--;
	                        	continue;
	                        }
	                        _n4 = _n3 | _card4;
	                        _i5 = _i4-- - 1;
                    	}
                        while(_i5 >= 0) {
                        	if(_i6 < 0) {
	                        	_card5 = HandEngine._cardMasksTable[_i5];
	                            if((dead & _card5) != 0) {
	                            	_i5--;
	                            	continue;
	                            }
	                            _n5 = _n4 | _card5;
	                            _i6 = _i5-- - 1;
                        	}
                            while(_i6 >= 0) {
                            	if(_i7 < 0) {
	                            	_card6 = HandEngine._cardMasksTable[_i6];
	                                if((dead & _card6) != 0) {
	                                	_i6--;
	                                	continue;
	                                }
	                                _n6 = _n5 | _card6;
	                                _i7 = _i6-- - 1;
                            	}
                                while(_i7 >= 0) {
                                    _card7 = HandEngine._cardMasksTable[_i7--];
                                    if ((dead & _card7) != 0) continue;
                                    return _n6 | _card7 | shared;
                                } // 7
                            } // 6
                        } // 5
                    } // 4
                } // 3
            } // 2
        } // 1

        throw new NoSuchElementException();
	}

	private long deckChoose6() throws NoSuchElementException {
    	if(_i1 < 0) _i1 = HandEngine.NUMBER_OF_CARDS - 1;
        while(_i1 >= 0) {
        	if(_i2 < 0) {
	        	_card1 = HandEngine._cardMasksTable[_i1];
	            if((dead & _card1) != 0) {
	            	_i1--;
	            	continue;
	            }
	            _i2 = _i1-- - 1;
        	}
            while(_i2 >= 0) {
            	if(_i3 < 0) {
	            	_card2 = HandEngine._cardMasksTable[_i2];
	                if((dead & _card2) != 0) {
	                	_i2--;
	                	continue;
	                }
	                _n2 = _card1 | _card2;
	                _i3 = _i2-- - 1;
            	}
                while(_i3 >= 0) {
                	if(_i4 < 0) {
	                	_card3 = HandEngine._cardMasksTable[_i3];
	                    if((dead & _card3) != 0) {
	                    	_i3--;
	                    	continue;
	                    }
	                    _n3 = _n2 | _card3;
	                    _i4 = _i3-- - 1;
                	}
                    while(_i4 >= 0) {
                    	if(_i5 < 0) {
	                    	_card4 = HandEngine._cardMasksTable[_i4];
	                        if((dead & _card4) != 0) {
	                        	_i4--;
	                        	continue;
	                        }
	                        _n4 = _n3 | _card4;
	                        _i5 = _i4-- - 1;
                    	}
                        while(_i5 >= 0) {
                        	if(_i6 < 0) {
	                        	_card5 = HandEngine._cardMasksTable[_i5];
	                            if((dead & _card5) != 0) {
	                            	_i5--;
	                            	continue;
	                            }
	                            _n5 = _n4 | _card5;
	                            _i6 = _i5-- - 1;
                        	}
                            while(_i6 >= 0) {
                                _card6 = HandEngine._cardMasksTable[_i6--];
                                if((dead & _card6) != 0) continue;
                                return _n5 | _card6 | shared;
                            } // 6
                        } // 5
                    } // 4
                } // 3
            } // 2
        } // 1

        throw new NoSuchElementException();
	}

	private long deckChoose5() throws NoSuchElementException {
    	if(_i1 < 0) _i1 = HandEngine.NUMBER_OF_CARDS - 1;
        while(_i1 >= 0) {
        	if(_i2 < 0) {
	        	_card1 = HandEngine._cardMasksTable[_i1];
	            if((dead & _card1) != 0) {
	            	_i1--;
	            	continue;
	            }
	            _i2 = _i1-- - 1;
        	}
            while(_i2 >= 0) {
            	if(_i3 < 0) {
	            	_card2 = HandEngine._cardMasksTable[_i2];
	                if((dead & _card2) != 0) {
	                	_i2--;
	                	continue;
	                }
	                _n2 = _card1 | _card2;
	                _i3 = _i2-- - 1;
            	}
                while(_i3 >= 0) {
                	if(_i4 < 0) {
	                	_card3 = HandEngine._cardMasksTable[_i3];
	                    if((dead & _card3) != 0) {
	                    	_i3--;
	                    	continue;
	                    }
	                    _n3 = _n2 | _card3;
	                    _i4 = _i3-- - 1;
                	}
                    while(_i4 >= 0) {
                    	if(_i5 < 0) {
	                    	_card4 = HandEngine._cardMasksTable[_i4];
	                        if((dead & _card4) != 0) {
	                        	_i4--;
	                        	continue;
	                        }
	                        _n4 = _n3 | _card4;
	                        _i5 = _i4-- - 1;
                    	}
                        while(_i5 >= 0) {
                            _card5 = HandEngine._cardMasksTable[_i5--];
                            if((dead & _card5) != 0) continue;
                            return _n4 | _card5 | shared;
                        } // 5
                    } // 4
                } // 3
            } // 2
        } // 1

        throw new NoSuchElementException();
	}

	private long deckChoose4() throws NoSuchElementException {
    	if(_i1 < 0) _i1 = HandEngine.NUMBER_OF_CARDS - 1;
        while(_i1 >= 0) {
        	if(_i2 < 0) {
	            _card1 = HandEngine._cardMasksTable[_i1];
	            if((dead & _card1) != 0) {
	            	_i1--;
	            	continue;
	            }
	            _i2 = _i1-- - 1;
        	}
            while(_i2 >= 0) {
            	if(_i3 < 0) {
	            	_card2 = HandEngine._cardMasksTable[_i2];
	                if((dead & _card2) != 0) {
	                	_i2--;
	                	continue;
	                }
	                _n2 = _card1 | _card2;
	                _i3 = _i2-- - 1;
            	}
                while(_i3 >= 0) {
                	if(_i4 < 0) {
	                	_card3 = HandEngine._cardMasksTable[_i3];
	                    if((dead & _card3) != 0) {
	                    	_i3--;
	                    	continue;
	                    }
	                    _n3 = _n2 | _card3;
	                    _i4 = _i3-- - 1;
                	}
                    while(_i4 >= 0) {
                        _card4 = HandEngine._cardMasksTable[_i4--];
                        if((dead & _card4) != 0) continue;
                        return _n3 | _card4 | shared;
                    } // 4
                } // 3
            } // 2
        } // 1

        throw new NoSuchElementException();
	}

	private long deckChoose3() throws NoSuchElementException {
    	if(_i1 < 0) _i1 = HandEngine.NUMBER_OF_CARDS - 1;
        while(_i1 >= 0) {
        	if(_i2 < 0) {
	        	_card1 = HandEngine._cardMasksTable[_i1];
	            if((dead & _card1) != 0) {
	            	_i1--;
	            	continue;
	            }
	            _i2 = _i1-- - 1;
        	}
            while(_i2 >= 0) {
                if(_i3 < 0) {
	                _card2 = HandEngine._cardMasksTable[_i2];
	                if((dead & _card2) != 0) {
	                	_i2--;
	                	continue;
	                }
                	_n2 = _card1 | _card2;
                	_i3 = _i2-- - 1;
                }
                while(_i3 >= 0) {
                	_card3 = HandEngine._cardMasksTable[_i3--];
                	if((dead & _card3) != 0) continue;
                    return _n2 | _card3 | shared;
                } // 3
            } // 2
        } // 1

        throw new NoSuchElementException();
	}
}