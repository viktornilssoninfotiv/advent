
#

from input import data
from collections import deque


def parse_input(input):
    p1_str, p2_str = input.split('\n\n')

    _, *p1 = p1_str.split('\n')
    _, *p2 = p2_str.split('\n')

    deck1 = deque()
    deck2 = deque()

    for c1, c2 in zip(p1, p2):
        deck1.append(int(c1))
        deck2.append(int(c2))

    return deck1, deck2


def simulate_game_1(input_deck1, input_deck2):
    deck1 = input_deck1.copy()
    deck2 = input_deck2.copy()

    while True:
        c1 = deck1.popleft()
        c2 = deck2.popleft()

        if c1 < c2:
            deck2.append(c2)
            deck2.append(c1)
        elif c2 < c1:
            deck1.append(c1)
            deck1.append(c2)
        else:
            print("error: equal cards")

        if len(deck1) == 0 or len(deck2) == 0:
            break

    return deck1, deck2


def simulate_game_2(deck1, deck2):
    prev_states = set()

    while True:
        # check if the hands have been played before
        s1 = ','.join(str(c) for c in deck1)
        s2 = ','.join(str(c) for c in deck2)
        curr_state = s1 + '\n' + s2
        
        if curr_state in prev_states:
            deck2.clear()
            break
        else:
            prev_states.add(curr_state)

        # deal cards
        c1 = deck1.popleft()
        c2 = deck2.popleft()

        winner = 0 # 1: player 1, 2: player 2
        if c1 > len(deck1) or c2 > len(deck2):
            # play normal round
            if c2 > c1:
                winner = 2
            elif c1 > c2:
                winner = 1
            else:
                print("error: equal cards")
        else:
            # play sub game
            d1 = deck1.copy()
            for _ in range(len(d1) - c1):
                d1.pop() 

            d2 = deck2.copy()
            for _ in range(len(d2) - c2):
                d2.pop()

            sub_deck1, _ = simulate_game_2(d1, d2)
            winner = 2 if len(sub_deck1) == 0 else 1

        # append cards to winner's deck
        if winner == 1:
            deck1.append(c1)
            deck1.append(c2)
        else:
            deck2.append(c2)
            deck2.append(c1)
        

        if len(deck1) == 0 or len(deck2) == 0:
            break

    return deck1, deck2


deck1, deck2 = parse_input(data)

# part 1

deck1f, deck2f = simulate_game_1(deck1.copy(), deck2.copy())
winning_deck = deck1f if len(deck2f) == 0 else deck2f

print(sum( (len(winning_deck) - i) * val for i, val in enumerate(winning_deck) ))


# part 2

deck1f, deck2f = simulate_game_2(deck1, deck2)

winning_deck = deck1f if len(deck2f) == 0 else deck2f
print(sum( (len(winning_deck) - i) * val for i, val in enumerate(winning_deck) ))


