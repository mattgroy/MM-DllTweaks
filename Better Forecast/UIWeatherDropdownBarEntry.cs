using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIWeatherDropdownBarEntry : MonoBehaviour
{
	/* CHANGED METHOD:
	public void SetVisibility(SessionInformationDropdown.DataType inDataType, float inTime, bool inHighlight, float inNormalizedSessionTime, float inTotalBarsCount)
	{
		this.weatherIcon.gameObject.SetActive(inDataType == SessionInformationDropdown.DataType.Clouds);
		this.label.gameObject.SetActive(inDataType == SessionInformationDropdown.DataType.Clouds);
		for (int i = 0; i < this.highLightContainer.Length; i++)
		{
			GameUtility.SetActive(this.highLightContainer[i], inHighlight);
		}
		HQsBuilding_v1 building = Game.instance.player.team.headquarters.GetBuilding(HQsBuildingInfo.Type.LogisticsCentre);
		int num = 5;
		if (building.isBuilt)
		{
			num += (building.currentLevel + 1) * 5;
		}
		float num2 = 1f / inTotalBarsCount * (float)num;
		if (inTime < inNormalizedSessionTime || inHighlight)
		{
			this.canvasGroup.alpha = 1f;
		}
		else if (inTime < inNormalizedSessionTime + num2)
		{
			this.label.text = "-";
			float num3 = inTime - inNormalizedSessionTime;
			float num4 = 1f / inTotalBarsCount * (float)num;
			this.canvasGroup.alpha = 1f - Mathf.Clamp01(num3 / num4);
		}
		else
		{
			this.canvasGroup.alpha = 0f;
		}
	}
	*/

	public void SetVisibility(SessionInformationDropdown.DataType inDataType, float inTime, bool inHighlight, float inNormalizedSessionTime, float inTotalBarsCount)
	{
		this.weatherIcon.gameObject.SetActive(inDataType == SessionInformationDropdown.DataType.Clouds);
		this.label.gameObject.SetActive(true);
		for (int i = 0; i < this.highLightContainer.Length; i++)
		{
			GameUtility.SetActive(this.highLightContainer[i], inHighlight);
		}
		HQsBuilding_v1 building = Game.instance.player.team.headquarters.GetBuilding(HQsBuildingInfo.Type.LogisticsCentre);
		int num = 5;
		if (building.isBuilt)
		{
			num += (building.currentLevel + 1) * 5;
		}
		float num2 = 1f / inTotalBarsCount * (float)num;
		if (inTime < inNormalizedSessionTime || inHighlight)
		{
			this.canvasGroup.alpha = 1f;
		}
		else if (inTime < inNormalizedSessionTime + num2)
		{
			float num3 = inTime - inNormalizedSessionTime;
			float num4 = 1f / inTotalBarsCount * (float)num;
			this.canvasGroup.alpha = 1f - Mathf.Clamp01(num3 / num4);
		}
		else
		{
			this.canvasGroup.alpha = 0f;
		}
	}

	private void ColorImages(Color inColor)
	{
		for (int i = 0; i < this.imagesToColor.Length; i++)
		{
			this.imagesToColor[i].color = inColor;
		}
	}

	/* CHANGED METHOD:
	public void SetupWaterData(float inWater, float inTime)
	{
		this.barSlider.minValue = 0f;
		this.barSlider.maxValue = 1f;
		GameUtility.SetSliderAmountIfDifferent(this.barSlider, inWater, 1000f);
		this.barSlider.image.color = this.barColorWater;
		this.ColorImages(this.barColorWater);
	}
	*/

	public void SetupWaterData(float inWater, float inTime)
	{
		this.label.text = inWater.ToString("P0");
		this.barSlider.minValue = 0f;
		this.barSlider.maxValue = 1f;
		GameUtility.SetSliderAmountIfDifferent(this.barSlider, inWater, 1000f);
		this.barSlider.image.color = this.barColorWater;
		this.ColorImages(this.barColorWater);
	}

	/* CHANGED METHOD:
	public void SetupRubberData(float inRubber, float inTime)
	{
		this.barSlider.minValue = 0f;
		this.barSlider.maxValue = 1f;
		GameUtility.SetSliderAmountIfDifferent(this.barSlider, inRubber, 1000f);
		this.barSlider.image.color = this.barColorRubber;
		this.ColorImages(this.barColorRubber);
	}
	*/

	public void SetupRubberData(float inRubber, float inTime)
	{
		this.label.text = inRubber.ToString("P0");
		this.barSlider.minValue = 0f;
		this.barSlider.maxValue = 1f;
		GameUtility.SetSliderAmountIfDifferent(this.barSlider, inRubber, 1000f);
		this.barSlider.image.color = this.barColorRubber;
		this.ColorImages(this.barColorRubber);
	}

	public void SetupCloudData(Weather inWeather, SessionWeatherDetails inWeatherDetails, float inTime)
	{
		this.weatherIcon.SetIcon(inWeather);
		this.label.text = GameUtility.GetTemperatureText((float)inWeather.airTemperature);
		this.barSlider.minValue = inWeatherDetails.minAirTemp - 3f;
		this.barSlider.maxValue = inWeatherDetails.maxAirTemp + 3f;
		GameUtility.SetSliderAmountIfDifferent(this.barSlider, (float)inWeather.airTemperature, 1000f);
		this.barSlider.image.color = this.barColorClouds;
		this.ColorImages(this.barColorClouds);
	}

	private void SetAlpha(float inTime)
	{
		float normalizedSessionTime = Game.instance.sessionManager.GetNormalizedSessionTime();
		if (inTime < normalizedSessionTime)
		{
			this.canvasGroup.alpha = 0.8f;
		}
		else
		{
			this.canvasGroup.alpha = 1f;
		}
	}

	public void ForceAlpha(float inValue)
	{
		GameUtility.SetActive(base.gameObject, true);
		this.canvasGroup.alpha = inValue;
	}

	public GameObject[] highLightContainer;

	public Image[] imagesToColor;

	public UIWeatherIcon weatherIcon;

	public TextMeshProUGUI label;

	public Slider barSlider;

	public Color barColorRubber = default(Color);

	public Color barColorWater = default(Color);

	public Color barColorClouds = default(Color);

	public CanvasGroup canvasGroup;
}
