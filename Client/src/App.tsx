import axios from "axios";
import { useEffect, useState } from "react";
import { List, ListItem, ListItemText, Typography } from "@mui/material";
import { API_BASE_URL } from "./lib/constants";

import type { Activity } from "./lib/types";

const App = () => {
  const [activities, setActivities] = useState<Activity[]>([]);
  useEffect(() => {
    const getActivities = async () => {
      const url = API_BASE_URL + "/activities";
      const response = await axios.get<Activity[]>(url);
      setActivities(response.data);
    };

    getActivities();

    return () => {};
  }, []);

  return (
    <>
      <Typography variant="h3">Reactivities</Typography>
      <List>
        {activities.map((activity) => (
          <ListItem key={activity.id}>
            <ListItemText>{activity.title}</ListItemText>
          </ListItem>
        ))}
      </List>
    </>
  );
};

export default App;
