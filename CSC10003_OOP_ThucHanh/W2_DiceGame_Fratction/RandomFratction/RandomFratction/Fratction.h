#pragma once
#include "Random.h"
#include "Integer.h"

class Fratction {
private:
	int TuSo;
	int MauSo;
	static Random _rd;

public:

	Fratction();
	int LayTuSo();
	void GanTuSo(int);

	int LayMauSo();
	void GanMauSo(int);
	void NhoNhat();
	Fratction operator+(Fratction f);
	friend ostream& operator<<(std::ostream& out, const Fratction& f);
	static Fratction PhatSinhSo();
};
