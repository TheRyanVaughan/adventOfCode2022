'''
A rock X
B paper Y
C scissor Z

get points by ord(char) - ord(X) + 1
'''

def points_for_playing(c):
    return ord(c) - ord('X') + 1
def beats(player, opp):
    return (player=='X' and opp=='C') or (player=='Y' and opp=='A') or (player=='Z' and opp=='B')
def ties(player, opp):
    return (player=='X' and opp=='A') or (player=='Y' and opp=='B') or (player=='Z' and opp=='C')
WIN_PTS = 6
TIE_PTS = 3
LOSE_PTS = 0
with open('input.txt') as f:
    pts = 0
    for line in f:
        a, b = line.strip().split(' ')
        pts += points_for_playing(b)
        if beats(b, a):
            pts += WIN_PTS
        elif ties(b, a):
            pts += TIE_PTS
print(pts)


def points_win(c):
    if c == 'Y':
        return TIE_PTS
    elif c == 'Z':
        return WIN_PTS
    else:
        return LOSE_PTS
with open('t1.txt') as f: 
    pts = 0
    for line in f:
        a, b = line.strip().split(' ')
        pts += points_win(b)

        if b == 'X':
            if a == 'A':
                pts += points_for_playing('Z')
            elif a == 'B':
                pts += points_for_playing('X')
            else:
                pts += points_for_playing('Y')
        elif b == 'Y':
            if a == 'A':
                pts += points_for_playing('X')
            elif a == 'B':
                pts += points_for_playing('Y')
            else:
                pts += points_for_playing('Z')
        else:
            if a == 'A':
                pts += points_for_playing('Y')
            elif a == 'B':
                pts += points_for_playing('Z')
            else:
                pts += points_for_playing('X')
print(pts)
