#include "isogram.h"
#include <ctype.h>

bool is_isogram(const char phrase[]) {

    if (!phrase) return false;

    char letter[26] = { false };
    for (int i = 0; phrase[i] != '\0'; i++) {
        char c = phrase[i];
        if (isalpha(c)) {
            int j = tolower(c) - 'a';
            if (letter[j]) return false;
            letter[j] = true;
        }
    }
    return true;
}
