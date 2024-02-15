#pragma once
#include "Random.h"

class EnglishVocabulary
{
private:
	Random rand;
	vector<string> EngList;
	vector<string> VieList;
public:
	EnglishVocabulary();
	~EnglishVocabulary();
	void learnVocabulary();
};