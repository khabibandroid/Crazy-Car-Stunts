using UnityEngine;
using System.Collections;

public enum eCAR_MODELS
{
	Car01,
	Car02,
	Car03,
	Car04,
	Car05
}
public enum eGAME_STATE
{
	None,
	Instruction,
	Mission,
	Help,
	GamePlay,
	LevelFailed,
	LevelComplete,
	Pause,
	BuyHEalth,
	SkipLevel,
	Rate,
	Share,
	DiedAnimation,
	ExtraTime,
	Store,
	ExitLevel,
	Tutorial

}
public enum eMENU_STATE
{
	None,
	Menu,
	Settings,
	Store,
	Shop,
	LevelSelection,
	CarSelection,
	UnblockCar,
	ExitGame,
	DailyBonus,
	CarDetails


}
public enum eSCENE_STATE
{
	None,
	Menu,
	CarSelection,
	GamePlay,
	Loading

}
public enum ePLAYER_STATE
{
	None,
	Driving,
	Gethit,
	Crashed
}
public enum eLEVEL_TYPE
{
	None,
	Parking,
	Score,
	Time_Based,
	Target_Based,
	Tailing,
	CheckPoint

}
public enum eTYPES_OF_TARGETS
{
	ParkingSlot,
	CheckPoints,
	Characters,
	None
}
public enum eCAMARA_TYPE
{
	None,
	ThirdPerson,
	Cockpit,
	TopViewCamera,
	FreeHand,
	Parking,
	Reverse
}
public enum eCONTROL_TYPE
{
	SteeringWheel,
	TouchButton
}
public static class StaticVAriables
{
	public static eCAR_MODELS mCarModels = eCAR_MODELS.Car01;
	public static eSCENE_STATE mCurrentScene = eSCENE_STATE.GamePlay;
	public static eGAME_STATE mGameState = eGAME_STATE.None;
	public static ePLAYER_STATE mPlayerState = ePLAYER_STATE.None;
	public static eMENU_STATE mMenuState = eMENU_STATE.None;
	public static eCONTROL_TYPE mControlState=eCONTROL_TYPE.TouchButton;
	public static eCAMARA_TYPE mCamaraState=eCAMARA_TYPE.ThirdPerson;
	public static eLEVEL_TYPE mLevelstate = eLEVEL_TYPE.None;


	//////****************  LEVEL DATA*****************///////
	public static int _iCurrentLevel=1;
	public static int _iLevelTarget=0;
	public static int _icurrentCar=1;
	public static int _iCurrentWorld	= 1;
	public static int _iScore = 0;
	public static int _iStarNo = 0;
	public static int iBestScore=0;

	public static float _fTimerForLevels=0;

	public static float _FbuttonClickDelay=0;

	public static string _SceneToLoad= "Menu Scene";
	public static string _BestLevelScore="BestScoreLevel";


	public static int LevelfailedCount=0;
	public static  int carSelectioncount=1;
	public static  int lvlSelectioncount=1;
	public static bool sv_bsound = true;

	public static string unlockcarscount;

}
