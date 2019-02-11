# GaugeExampleDemo
Gauge Framework + Selenium WebDriver + NUnit + FileHelpers (CSV files)

Notes:
- Application URL can be changed in the following route : "Cignium/env/default.properties". Url property is APP_BASEURL.
- Browsers supported for testing : Chrome, Firefox, IE. (You can configure what Browser to use by changing the "browser" property).
- Test can be ran in parallel mode by using the following command: "gauge run --parallel Specs/"
- Automation test can be ran by using the following command : "gauge run Specs/". (You must be located at Cignium folder)
- Every time the test are ran, a report folder is generated. (Readable Report)
- Screenshots are enabled. If that want to be changed, set the "screenshot_on_failure" property to false. (Property is located at default.properties).
- DataGenerator class was created to generate random data.

# Prerequisites
- [Install Gauge](http://getgauge.io/get-started/index.html)
- [Install Gauge-CSharp plugin](https://docs.gauge.org/latest/installation.html#language-plugins)
- .NET v4.5 (required for the CSharp plugin to run), you could write your test code to target a lesser version.
- Gauge Visual Studio plugin (optional, but recommended)

# Concepts covered

- Use [Webdriver](http://docs.seleniumhq.org/projects/webdriver/) as base of implementation
- [Concepts](https://docs.gauge.org/latest/writing-specifications.html#concepts)
- [Specification](https://docs.gauge.org/latest/writing-specifications.html#specifications-spec), [Scenario](https://docs.gauge.org/latest/writing-specifications.html#scenario) & [Step](https://docs.gauge.org/latest/writing-specifications.html#step) usage
- [External datasource (special param)](https://docs.gauge.org/latest/writing-specifications.html#special-parameters)
