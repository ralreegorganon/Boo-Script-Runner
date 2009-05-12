import System.Web
import System.Web.UI
import System.Web.UI.WebControls

class Bypass(Demo.Default):
	def Hack():
		page = HttpContext.Current.Handler as Demo.Default
		label = Label()
		label.Text = "Oh snap!"
		page.Controls.Add(label)
		
b = Bypass()
b.Hack()