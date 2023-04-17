Attachment::AddBefore("Player::onDamage",	"HitSounds::OnDamage");

function HitSounds::OnDamage(%this, %type, %value, %pos, %vec, %mom, %vertPos, %quadrant, %object)
{
	%shooterClient = Player::getClient(%object);
	
	if (%shooterClient.hitSoundsDisabled || %type == 0)
		return;
	else
	{
		%damagedClient = Player::getClient(%this);
		
		// Team damage not on self
		if (%shooterClient != %damagedClient) { // we check this anyway so filter first
			
			%damagedClientTeam = Client::getTeam(%damagedClient); // move these inside
			%shooterClientTeam = Client::getTeam(%shooterClient);
			
			if(%shooterClientTeam != %damagedClientTeam)
				Client::sendMessage(%shooterClient, 0, "~C_BuySell.wav");
		}
	}
}
