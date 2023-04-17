Attachment::AddBefore("Player::onDamage",	"HitSounds::OnDamage");

function HitSounds::OnDamage(%this, %type, %value, %pos, %vec, %mom, %vertPos, %quadrant, %object)
{
	if ($HitSounds::enabled)
	{
		//damage from impact etc.
		if(%type == 0) 
			return;

		%shooterClient = %object;
		%damagedClient = Player::getClient(%this);
		
		// Team damage not on self
		if (%shooterClient != %damagedClient) { // we check this anyway so filter first
			
			%damagedClientTeam = Client::getTeam(%damagedClient); // move these inside
			%shooterClientTeam = Client::getTeam(%shooterClient);
			Client::sendMessage(%shooterClient, 0, "~whit.wav");
		}
	}
}
