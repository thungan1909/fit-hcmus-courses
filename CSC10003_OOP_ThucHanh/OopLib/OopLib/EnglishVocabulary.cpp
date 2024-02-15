#include "EnglishVocabulary.h"

EnglishVocabulary::EnglishVocabulary()
{
	EngList.resize(10);
	VieList.resize(10);
	EngList = { "atmosphere","biodiversity","catastrophe","climate","contaminated",
	"creature","deforestation","desertification","drought","ecosystem" };
	VieList = { "khi quyen", "su da dang sinh hoc","tham hoa","khi hau","lam ban",
		"sinh vat","chay rung","qua trinh sa mac hoa","han han","he sinh thai" };
}

EnglishVocabulary::~EnglishVocabulary()
{
	EngList.clear();
	VieList.clear();
}

void EnglishVocabulary::learnVocabulary()
{
	int n = rand.nextInt(EngList.size());
	cout << EngList[n] << " - " << VieList[n] << endl;
}