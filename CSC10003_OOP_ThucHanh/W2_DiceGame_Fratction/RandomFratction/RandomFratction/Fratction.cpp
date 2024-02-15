#include "Fratction.h"
Fratction::Fratction()
{
	TuSo = 0; MauSo = 1;
}

int Fratction::LayTuSo()
{
	return TuSo;
}
void Fratction::GanTuSo(int value) {
	TuSo = value;
}
int Fratction::LayMauSo()
{
	return MauSo;
}
void Fratction::GanMauSo(int value) 
{
	MauSo = value;
}

void Fratction::NhoNhat() {
	int GCDivisor = Integer::gcd(TuSo, MauSo);
	TuSo /= GCDivisor;
	MauSo /= GCDivisor;
}
Fratction Fratction::operator+(Fratction f)
{
	Fratction temp;
	temp.GanTuSo(TuSo * f.LayMauSo() + f.LayTuSo() * MauSo);
	temp.GanMauSo(MauSo * f.LayMauSo());
	temp.NhoNhat();
	return temp;
}

ostream& operator<<(std::ostream& out, const Fratction& f) {
	if (f.TuSo == 0 || f.MauSo == 1) {
		out << f.TuSo;
	}
	else {
		out << f.TuSo << "/" << f.MauSo;
	};

	return out;
}

Fratction Fratction::PhatSinhSo()
{
	Fratction f;
	Random rd = _rd;

	f.GanTuSo(rd.nextInt(0, 10));
	f.GanMauSo(rd.nextInt(1, 20));
	f.NhoNhat();
	return f;
}